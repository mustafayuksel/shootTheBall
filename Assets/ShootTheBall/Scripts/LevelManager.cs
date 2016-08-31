using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public Ring[] allRings;
	public Level[] allLevels;
	public int maxLevel = 32;
	public int currentLevelIndex = 10;
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

		loadAllLevels ();
		currentLevel = allLevels [currentLevelIndex];
		currentLevel.setupRing ();
		currentRing = currentLevel.ring;
		InvokeRepeating ("onTimerTick", 1f, 1f);
		currentLevel.timerActive = true;
		currentRing.gameObject.SetActive (true);
		if (currentLevel.ring2 != null) {
			
			ring2 = currentLevel.ring2;
			ring2.gameObject.SetActive (true);
		}


	}

	public void loadNextLevel() {

	}

	public void playAgain() {

	}

	public void resetGame() {

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
			setTimeOut(10f).build ();

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
			setTimeOut(20f).build ();

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
			setTimeOut(10f).build ();



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
			.setRing1MinSpeed (150).setRing2MinSpeed(20)
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
		allLevels [23] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setRing2(allRings[5]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (50).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(40f).build ();

		//beğenmezsen uçur reyiz --mustafa
		allLevels [24] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setRing2(allRings[5]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (100).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000).build ();

		//beğenmezsen uçur reyiz --mustafa
		allLevels [25] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setRing2(allRings[6]).setLevelNumber (1)
			.setRing1Direction(1.0f).setRing2Direction(-1.0f)
			.setRing1AnimType(EGTween.EaseType.linear).setRing2AnimType(EGTween.EaseType.linear)
			.setRing1MinSpeed (100).setRing2MinSpeed(20)
			.setRing1MaxSpeed (150).setLevelUpCount (5).
			setTimeOut(1000).build ();




	


	}

	public void OnLevelUp() {
		if (GamePlay.instance.isGamePlay) {
			currentLevelIndex++;
			if (currentLevelIndex < maxLevel) {
				GameObject oldRing = currentLevel.ring.gameObject;
				if (currentLevel.ring2 != null) {
					currentLevel.ring2.gameObject.SetActive (false);
				}
				oldRing.SetActive (false);
				currentLevel = allLevels [currentLevelIndex];
				currentLevel.setupRing (); // Aynı ringleri kullandığımız için son objenin hız değerlerini alıyor(du)
				currentRing = currentLevel.ring;
				currentRing.gameObject.SetActive (true);
				if (currentLevel.ring2 != null) {
					currentLevel.ring2.gameObject.SetActive (true);
				}
				stopCountDown ();
				GameController.instance.OnLevelUp ();
			} else {
				GameController.instance.OnGameFinished ();
			}
		}

	}

	public void onTimerTick() {

		if (currentLevel.hasTimeOut() && currentLevel.timerActive) {
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

		currentLevel.resetTimer ();
		TickSoundController.instance.stopTickSound ();
	}





}
