using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GamePlay : MonoBehaviour, IPointerDownHandler
{
	public static GamePlay instance;
	public Text txtScore;
	public SpriteRenderer sp_background;

	public AudioClip SuccessHit;
	public AudioClip RingHit;
	private bool isGameOver = false;
	private int isTutorial1Shown;
	private int isTutorial2Shown;

	public Image clock;

	public List<Color> BGColors = new List<Color>();

	[HideInInspector] public int score = 0;
	[HideInInspector] public int bestScore = 0;
	[HideInInspector] public bool isGamePlay; 


	// event for score updation.
	public static event Action<int> OnScoreUpdatedEvent;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		if (instance == null) {
			instance = this;
			return;
		}
	}

	void Update() {
		if (clock.enabled) {
			if (LevelManager.instance.currentLevel.hasTimeOut ()) {
				clock.fillAmount = LevelManager.instance.currentLevel.timeOut / LevelManager.instance.currentLevel.totalTimeOut;
			}
		}
	}

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		
		Debug.Log ("Current Level Index:" + LevelManager.instance.currentLevelIndex);
		LevelManager.instance.currentLevel = LevelManager.instance.allLevels [LevelManager.instance.currentLevelIndex];
		LevelManager.instance.startCountDown ();
		score = LevelManager.instance.currentLevel.levelUpCount;
		clock.enabled = false;
		if (LevelManager.instance.currentLevel.hasTimeOut ()) {

		//	LevelManager.instance.currentLevel.timerActive = true;
			clock.enabled = true;
			clock.fillClockwise = false;
			clock.fillAmount = LevelManager.instance.currentLevel.timeOut / 80;
		}

		isGameOver = false;
		BGMusicController.instance.StartBGMusic ();
		bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		isGamePlay = true;

		if (PlayerPrefs.GetInt ("isRescued", 0) == 1) {
			score = PlayerPrefs.GetInt ("LastScore", 0);
		} else {
			SetBackgroundColor ();
			score = LevelManager.instance.currentLevel.levelUpCount;
		}
		isTutorial1Shown = PlayerPrefs.GetInt ("tutorial1", 0);
		isTutorial2Shown = PlayerPrefs.GetInt ("tutorial2");

		if (LevelManager.instance.currentLevelIndex == 0 && isTutorial1Shown == 0) {

			Invoke ("showTutorial1", 2f);
		}
		if (LevelManager.instance.currentLevelIndex == 3 && isTutorial2Shown == 0) {

			Invoke ("showTutorial2", 2f);

		}
		txtScore.text = score.ToString ("00");
		Invoke ("ResetPrefs", 1F);
	}

	/// <summary>
	/// Resets the prefs.
	/// </summary>
	void ResetPrefs(){
		PlayerPrefs.DeleteKey ("LastScore");
		PlayerPrefs.DeleteKey ("isRescued");
	}

	/// <summary>
	/// Raises the game over event.
	/// </summary>
	public void OnGameOver ()
	{
		isGameOver = true;
		PlayerPrefs.SetInt ("LastScore", score);
	
		if (AudioManager.instance.isSoundEnabled) {
			GetComponent<AudioSource> ().PlayOneShot (RingHit);

		}

		Invoke ("ExecuteGameOver", 1F);
	}

	void ExecuteGameOver()
	{
		#if !UNITY_EDITOR
		LeaderBoard.instance.postScore ();
		#endif
		LevelManager.instance.stopCountDown ();
		GameController.instance.OnGameOver (gameObject);

	}

	/// <summary>
	/// Raises the score updated event.
	/// </summary>
	/// <param name="count">Count.</param>
	public void OnScoreUpdated (int count)
	{
		score -= count;
		txtScore.text = score.ToString ("00");
	
		//OnScoreUpdatedEvent.Invoke (score);

		if (score == 0 && !isGameOver) {
			
			Invoke ("levelUp", 0.5f);
		}

	/*	if (score > bestScore) {
			bestScore = score;
			PlayerPrefs.SetInt ("BestScore", bestScore);
		}   */
		if (AudioManager.instance.isSoundEnabled) {
			GetComponent<AudioSource> ().PlayOneShot (SuccessHit);
		}
	}

	/// <summary>
	/// Sets the color of the background from the predefined list if colors randomly.
	/// </summary>
	void SetBackgroundColor()
	{
		//sp_background.color = BGColors [UnityEngine.Random.Range (0, BGColors.Count)];;

		sp_background.color = BGColors [0];
	}


	#region IPointerDownHandler implementation
	/// <summary>
	/// Raises the pointer down event.
	/// Ball will be fired on pointer down in gameplay mode.
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnPointerDown (PointerEventData eventData)
	{
		if (isGamePlay) 
		{
			Cannon.instance.FireBall();	
		}
	}
	#endregion

	/// <summary>
	/// Raises the pause button pressed event.
	/// </summary>
	public void OnPauseButtonPressed()
	{
		if (InputManager.instance.canInput ()) {
			InputManager.instance.DisableTouchForDelay ();
			InputManager.instance.AddButtonTouchEffect ();
			GameController.instance.PauseGame();
		}
	}
	public void levelUp() {
		if (!isGameOver) {
			LevelManager.instance.OnLevelUp ();
			SetBackgroundColor ();
			score = LevelManager.instance.currentLevel.levelUpCount;
		}
	}

	public void loadLevel(int levelNum) {

		Debug.Log ("loadLevel");
		LevelManager.instance.setCurrentLevel (levelNum);
		GameController.instance.ReloadGame (GameController.instance.LastScreen);
	}

	public void showTutorial1() {
		if (!isGameOver) {
			GameController.instance.Tutorial1 ();
			PlayerPrefs.SetInt ("tutorial1", 1);
		}
	}
	public void showTutorial2() {

		if (!isGameOver) {

			GameController.instance.Tutorial2 ();
			PlayerPrefs.SetInt ("tutorial2", 1);
		}
	}
}
