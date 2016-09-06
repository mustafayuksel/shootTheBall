using UnityEngine;
using System.Collections;

public class LevelUpScreen : MonoBehaviour {


	public void OnContinueButtonPressed() {
		Debug.Log ("sdsf");
		GameController.instance.OnContinueButtonPressed ();
	}

	public void OnReplayButtonPressed() {
			if (InputManager.instance.canInput ()) {
				GamePlay.instance.ResetPrefs ();
				LevelManager.instance.currentLevelIndex--;
				InputManager.instance.DisableTouchForDelay ();
				InputManager.instance.AddButtonTouchEffect ();
				GameController.instance.OnContinueButtonPressed ();

			}

	}

	public void OnHomeButtonPressed ()
	{
		if (InputManager.instance.canInput ()) {
			InputManager.instance.DisableTouchForDelay ();
			InputManager.instance.AddButtonTouchEffect ();
			GameController.instance.ExitToMainScreenFromGameOver(gameObject);
		}
	}
}
