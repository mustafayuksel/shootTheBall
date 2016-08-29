using UnityEngine;
using System.Collections;

public class LevelUpScreen : MonoBehaviour {


	public void OnContinueButtonPressed() {
		Debug.Log ("sdsf");
		GameController.instance.OnContinueButtonPressed ();
	}
}
