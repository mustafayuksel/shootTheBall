using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLevelScreen : MonoBehaviour {

	public Text lvlText;


	void Start() {
		
	}
	void OnEnable() {
		lvlText.text = (LevelManager.instance.currentLevelIndex + 1) + "";
	}
}
