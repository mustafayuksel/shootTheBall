using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour 
{
	// The score text
	public Text txtScore;
	// The Best score text 
	public Text txtBestScore;

	public Button rescueButton;

	public AudioClip GameOverAudio;

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
		BGMusicController.instance.StopBGMusic ();
		if (AudioManager.instance.isSoundEnabled) {
			GetComponent<AudioSource>().PlayOneShot(GameOverAudio);
		}

		// Sets score and best score.
		txtBestScore.text = PlayerPrefs.GetInt ("BestScore", 0).ToString();
		txtScore.text = PlayerPrefs.GetInt ("LastScore", 0).ToString();

		#if UNITY_ANDROID || UNITY_IOS
	
		#endif

		/*if ((PlayerPrefs.GetInt ("isRescued", 0) == 0) && (LevelManager.instance.currentLevel.timeOut > 0) 
			&& GoogleAdsense.instance.isReady()) {
			rescueButton.gameObject.SetActive (true);
		} else {
			rescueButton.gameObject.SetActive (false);

		}*/

		float i = UnityEngine.Random.Range (0, 8);
		Debug.Log ("random variable=" + i);
		if (i < 1) {
			if (GoogleAdsense.instance.isReady ()) {
				GoogleAdsense.instance.showInterstitialAd ();
			}
		}


	}

	/// <summary>
	/// Raises the replay button pressed event.
	/// </summary>
	public void OnReplayButtonPressed ()
	{
		if (InputManager.instance.canInput ()) {
			GamePlay.instance.ResetPrefs ();
			InputManager.instance.DisableTouchForDelay ();
			InputManager.instance.AddButtonTouchEffect ();
			GameController.instance.ReloadGame(gameObject);

		}
	}

	/// <summary>
	/// Raises the home button pressed event.
	/// </summary>
	public void OnHomeButtonPressed ()
	{
		if (InputManager.instance.canInput ()) {
			InputManager.instance.DisableTouchForDelay ();
			InputManager.instance.AddButtonTouchEffect ();
			GameController.instance.ExitToMainScreenFromGameOver(gameObject);
		}
	}

	/// <summary>
	/// Raises the rescue button pressed event.
	/// </summary>
	public void OnRescueButtonPressed()
	{
		if (InputManager.instance.canInput ()) {
			InputManager.instance.DisableTouchForDelay ();
			InputManager.instance.AddButtonTouchEffect ();

			BGMusicController.instance.StopBGMusic ();	

			#if UNITY_ANDROID || UNITY_IOS
			GoogleAdsense.instance.showInterstitialAd();
			float timeout = 0f;
			PlayerPrefs.SetFloat("timeout",LevelManager.instance.currentLevel.timeOut);
			PlayerPrefs.SetInt("isRescued",1);
			GameController.instance.ReloadGame(gameObject);
			#endif
		}
	}
}
