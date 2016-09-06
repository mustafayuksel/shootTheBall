using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public Ring[] allRings;
	public Level[] allLevels;
	public int maxLevel = 32;
	public int currentLevelIndex = 0;
	public Level currentLevel;
	private Ring currentRing;
	private Ring ring2;

	public static LevelManager instance;


	void Awake() {
		if (instance == null) {
			instance = this;
			return;
		}

		Destroy (gameObject);
	}
		
	void Start() {


		Debug.Log ("Start");
		loadAllLevels ();
		//resetGame ();
		currentLevelIndex = PlayerPrefs.GetInt ("level", 0);
		setCurrentLevel (currentLevelIndex);


	}
		

	public void resetGame() {

		PlayerPrefs.SetInt ("level", 0);
		PlayerPrefs.SetInt ("tutorial1", 0);
		PlayerPrefs.SetInt ("tutorial2", 0);
	}


	public void loadAllLevels() {

		allLevels = new Level[maxLevel];
		LevelBuilder builder = new LevelBuilder ();
		allLevels [0] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1).setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing1MinSpeed (50).setRing1MaxSpeed (150).setLevelUpCount (5)
			.setTimeOut(1000).build ();

		allLevels [1] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setLevelNumber (1).setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing1MinSpeed (50).setRing1MaxSpeed (150).setLevelUpCount (5)
			.setTimeOut(1000).build ();
		

		allLevels [2] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000f).build ();

		allLevels [3] =  builder.setLevel (new Level ()).setRing1 (allRings [3]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(15f).build ();


		allLevels [4] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1).setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.easeInExpo).setRing1MinSpeed (100).setRing1MaxSpeed (150).setLevelUpCount (5)
			.setTimeOut(1000).build ();



		allLevels [5] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setLevelNumber (1).setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.easeInOutBack).setRing1MinSpeed (100).setRing1MaxSpeed (150).setLevelUpCount (5)
			.setTimeOut(1000).build ();


		allLevels [6] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.easeOutExpo)
			.setRing1MinSpeed (100)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000f).build ();

		allLevels [7] =  builder.setLevel (new Level ()).setRing1 (allRings [3]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(15f).build ();


		allLevels [8] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setRing2(allRings[5]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (100).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000).build ();

		allLevels [9] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1).setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing1MinSpeed (150).setRing1MaxSpeed (150).setLevelUpCount (5)
			.setTimeOut(10).build ();

		allLevels [10] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setLevelNumber (1).setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing1MinSpeed (50).setRing1MaxSpeed (150).setLevelUpCount (5)
			.setTimeOut(10).build ();


		allLevels [11] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setRing2(allRings[5]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(15).build ();

		allLevels [12] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setRing2(allRings[6]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.easeInOutExpo).setRing2AnimType(EGTween.EaseType.easeInOutExpo)
			.setRing1MinSpeed (50).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(40).build ();


		allLevels [13] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (100)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(1000f).build ();



		allLevels [14] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.easeInBack)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(15f).build ();


		allLevels [15] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setRing2(allRings[7]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.easeInExpo).setRing2AnimType(EGTween.EaseType.easeInExpo)
			.setRing1MinSpeed (150).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(20).build ();

		allLevels [16] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setRing2(allRings[5]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear).setRing1LoopType(EGTween.LoopType.pingPong)
			.setRing1MinSpeed (100).setRing2MinSpeed(50)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(20).build ();



		allLevels [17] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(10f).build ();


		allLevels [18] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1).setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.easeInOutExpo).setRing1MinSpeed (150).setRing1MaxSpeed (150).setLevelUpCount (5).setRing1LoopType(EGTween.LoopType.pingPong)
			.setTimeOut(5).build ();


		allLevels [19] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setRing2(allRings[6]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.easeInOutExpo).setRing2AnimType(EGTween.EaseType.easeInOutExpo).setRing1LoopType(EGTween.LoopType.pingPong)
			.setRing1MinSpeed (50).setRing2MinSpeed(20).setRing2LoopType(EGTween.LoopType.pingPong)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(40).build ();


		allLevels [20] =  builder.setLevel (new Level ()).setRing1 (allRings [3]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (5).setRing1LoopType(EGTween.LoopType.pingPong).
			setTimeOut(15f).build ();


		allLevels [21] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setRing2(allRings[6]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear).setRing1LoopType(EGTween.LoopType.pingPong)
			.setRing1MinSpeed (50).setRing2MinSpeed(50).setRing2LoopType(EGTween.LoopType.pingPong)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(40).build ();



		allLevels [22] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setRing2(allRings[4]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear).setRing1LoopType(EGTween.LoopType.pingPong)
			.setRing1MinSpeed (50).setRing2MinSpeed(50).setRing2LoopType(EGTween.LoopType.pingPong)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(40).build ();


		//beğenmezsen uçur reyiz --mustafa
		allLevels [23] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setRing2(allRings[5]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (100).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000).build ();

		//beğenmezsen uçur reyiz --mustafa
		allLevels [24] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setRing2(allRings[6]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (100).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000).build ();

		allLevels [25] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(10f).build ();



		allLevels [26] = builder.setLevel (new Level ()).setRing1 (allRings [8]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(20f).build ();



		allLevels [27] = builder.setLevel (new Level ()).setRing1 (allRings [9]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (4).
			setTimeOut(15f).build ();


		allLevels [28] = builder.setLevel (new Level ()).setRing1 (allRings [10]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000f).build ();


		allLevels [29] = builder.setLevel (new Level ()).setRing1 (allRings [10]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (100)
			.setRing1MaxSpeed (150).setLevelUpCount (3).
			setTimeOut(1000f).build ();



		allLevels [30] = builder.setLevel (new Level ()).setRing1 (allRings [8]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.easeInExpo).setRing1LoopType(EGTween.LoopType.pingPong)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (8).
			setTimeOut(15f).build ();


		allLevels [31] = builder.setLevel (new Level ()).setRing1 (allRings [10]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2(allRings[1])
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (3).
			setTimeOut(1000f).build ();
		

		allLevels [32] = builder.setLevel (new Level ()).setRing1 (allRings [9]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (4).
			setTimeOut(15f).build ();

		allLevels [33] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (15).
			setTimeOut(15f).build ();

		allLevels [34] = builder.setLevel (new Level ()).setRing1 (allRings [10]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (100)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(1000f).build ();

		allLevels [35] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setRing2(allRings[6]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear).setRing1LoopType(EGTween.LoopType.loop)
			.setRing1MinSpeed (100).setRing2MinSpeed(50).setRing2LoopType(EGTween.LoopType.loop)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000f).build ();

		allLevels [36] =  builder.setLevel (new Level ()).setRing1 (allRings [3]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (20).setRing1LoopType(EGTween.LoopType.loop).
			setTimeOut(15f).build ();


		allLevels [37] = builder.setLevel (new Level ()).setRing1 (allRings [10]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing1LoopType(EGTween.LoopType.loop)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(15f).build ();

	

		allLevels [38] = builder.setLevel (new Level ()).setRing1 (allRings [10]).setLevelNumber (1)
			.setRing1Direction (1.0f).setRing2 (allRings [1]).setRing2MinSpeed (20)
			.setRing2AnimType(EGTween.EaseType.linear).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000f).build ();


	

		allLevels [39] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setRing2(allRings[7]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150).setRing2MinSpeed(50)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(20).build ();


		allLevels [40] = builder.setLevel (new Level ()).setRing1 (allRings [11])
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (1).
			setTimeOut(1000f).build ();
	

		allLevels [41] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setRing2(allRings[8]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(1000f).build ();


		allLevels [42] = builder.setLevel (new Level ()).setRing1 (allRings [2])
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (10).
			setTimeOut(5f).build ();


		allLevels [43] = builder.setLevel (new Level ()).setRing1 (allRings [11])
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (2).
			setTimeOut(1000f).build ();

		allLevels [44] = builder.setLevel (new Level ()).setRing1 (allRings [10]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2(allRings[1])
			.setRing1AnimType(EGTween.EaseType.linear).setRing2Direction(-1.0f)
			.setRing1MinSpeed (150)
			.setRing2AnimType(EGTween.EaseType.linear)
			.setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (2).
			setTimeOut(1000f).build ();

		allLevels [45] = builder.setLevel (new Level ()).setRing1 (allRings [10]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2(allRings[1])
			.setRing1AnimType(EGTween.EaseType.linear).setRing2Direction(-1.0f)
			.setRing1MinSpeed (150)
			.setRing2AnimType(EGTween.EaseType.linear)
			.setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (2).
			setTimeOut(1000f).build ();

	
		allLevels [46] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setRing2(allRings[8]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing2MinSpeed(50)
			.setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (150)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000f).build ();


		allLevels [47] = builder.setLevel (new Level ()).setRing1 (allRings [9]).setRing2(allRings[8]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(15).build ();

		allLevels [48] = builder.setLevel (new Level ()).setRing1 (allRings [9]).setLevelNumber (1)
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing1LoopType(EGTween.LoopType.loop)
			.setRing1MinSpeed (100)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(10f).build ();

		allLevels [49] = builder.setLevel (new Level ()).setRing1 (allRings [11])
			.setRing1Direction(1.0f)
			.setRing1AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50)
			.setRing1MaxSpeed (150).setLevelUpCount (2).
			setTimeOut(20).build ();






	}

	public void OnLevelUp() {
		Debug.Log ("On level Up");
		if (GamePlay.instance.isGamePlay) {
			currentLevelIndex++;
			if (currentLevelIndex < maxLevel) {
				int lastLevel = PlayerPrefs.GetInt ("level", 0);
				if (lastLevel < currentLevelIndex + 1) {
					Debug.Log ("Current level set");
					PlayerPrefs.SetInt ("level", currentLevelIndex);
				}
				setCurrentLevel (currentLevelIndex);
				stopCountDown ();
				GameController.instance.OnLevelUp ();
			} else {
				GameController.instance.OnGameFinished ();
			}
		}

	}

	public void onTimerTick() {

		if (currentLevel.hasTimeOut() && currentLevel.timerActive && !GameController.instance.isGamePaused) {
			currentLevel.timeOut--;
			if (currentLevel.timeOut < 0) {
				TickSoundController.instance.stopTickSound ();
				currentLevel.resetTimer ();
				GameController.instance.OnGameOver (GameController.instance.LastScreen);
			}	
			if (currentLevel.timeOut < Level.TIMEOUT_CRITICAL) {

				if (AudioManager.instance.isSoundEnabled) {
					TickSoundController.instance.startTickSound ();
				}
			}
		}
	}

	public void stopCountDown() {

		CancelInvoke ();
		//currentLevel.resetTimer ();
		currentLevel.timerActive = false;
		TickSoundController.instance.stopTickSound ();
	}

	public void setCurrentLevel(int levelNum) {

		if (currentLevel != null) {
			if (currentLevel.ring != null) {
				GameObject oldRing = currentLevel.ring.gameObject;
				oldRing.SetActive (false);
			}
			if (currentLevel.ring2 != null) {
				currentLevel.ring2.gameObject.SetActive (false);
			}
		}
		currentLevelIndex = levelNum;
		currentLevel = allLevels [currentLevelIndex];
		currentLevel.setupRing ();
		currentRing = currentLevel.ring;
		currentLevel.timerActive = false;
		currentRing.gameObject.SetActive (true);
		if (currentLevel.ring2 != null) {

			ring2 = currentLevel.ring2;
			ring2.gameObject.SetActive (true);
		}
		currentLevel.resetTimer ();

	}

	public void startCountDown() {
		currentLevel.timerActive = true;
		InvokeRepeating ("onTimerTick", 1f, 1f);
	}





}
