using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public Ring[] allRings;
	public Level[] allLevels;
	public int maxLevel = 16;
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
		loadAllLevels ();
		currentLevel = allLevels [currentLevelIndex];
		currentLevel.setupRing ();
		currentRing = currentLevel.ring;
		currentRing.gameObject.SetActive (true);
	}


	public void loadAllLevels() {

		allLevels = new Level[maxLevel];
		LevelBuilder builder = new LevelBuilder ();
		allLevels [0] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1)
			.setRing1MinSpeed (50).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [1] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setLevelNumber (1)
			.setRing1MinSpeed (50).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [2] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setLevelNumber (1)
			.setRing1MinSpeed (50).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [3] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setLevelNumber (1)
			.setRing1MinSpeed (50).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [4] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1)
			.setRing1MinSpeed (100).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [5] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setLevelNumber (1)
			.setRing1MinSpeed (100).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [6] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setLevelNumber (1)
			.setRing1MinSpeed (100).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [7] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setLevelNumber (1)
			.setRing1MinSpeed (100).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [8] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1)
			.setRing1MinSpeed (150).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [9] = builder.setLevel (new Level ()).setRing1 (allRings [0]).setLevelNumber (1)
			.setRing1MinSpeed (150).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [10] = builder.setLevel (new Level ()).setRing1 (allRings [2]).setLevelNumber (1)
			.setRing1MinSpeed (150).setRing1MaxSpeed (150).setLevelUpCount (5).build ();
		allLevels [11] = builder.setLevel (new Level ()).setRing1 (allRings [3]).setLevelNumber (1)
			.setRing1MinSpeed (150).setRing1MaxSpeed (150).setLevelUpCount (5).build ();

		allLevels [12] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1)
			.setRing1MinSpeed (50).setRing1MaxSpeed (150).setRing2(allRings[5])
			.setRing2MinSpeed(50).setRing2MaxSpeed(150).setLevelUpCount (5).build ();
		allLevels [13] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1)
			.setRing1MinSpeed (50).setRing1MaxSpeed (150).setRing2(allRings[5])
			.setRing2MinSpeed(50).setRing2MaxSpeed(150).setLevelUpCount (5).build ();
		allLevels [14] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1)
			.setRing1MinSpeed (50).setRing1MaxSpeed (150).setRing2(allRings[5])
			.setRing2MinSpeed(50).setRing2MaxSpeed(150).setLevelUpCount (5).build ();
		allLevels [15] = builder.setLevel (new Level ()).setRing1 (allRings [1]).setLevelNumber (1)
			.setRing1MinSpeed (50).setRing1MaxSpeed (150).setRing2(allRings[5])
			.setRing2MinSpeed(50).setRing2MaxSpeed(150).setLevelUpCount (5).build ();



	}

	public void OnLevelUp() {
		currentLevelIndex++;
		if (currentLevelIndex < maxLevel) {
			GameObject oldRing = currentLevel.ring.gameObject;
			oldRing.SetActive (false);
			currentLevel = allLevels [currentLevelIndex];
			currentLevel.setupRing (); // Aynı ringleri kullandığımız için son objenin hız değerlerini alıyor(du)
			currentRing = currentLevel.ring;
			currentRing.gameObject.SetActive (true);
			if (currentLevel.ring2 != null) {
				currentLevel.ring2.gameObject.SetActive (true);
			}
			GameController.instance.OnLevelUp ();
		} else {
			GameController.instance.OnGameFinished ();
		}
	}

}
