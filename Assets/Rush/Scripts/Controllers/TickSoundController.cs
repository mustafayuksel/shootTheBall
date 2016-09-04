using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class TickSoundController : MonoBehaviour {

	public static TickSoundController instance;

	void Awake() {
		if (instance == null) {

			instance = this;
			return;
		}

		Destroy (gameObject);
	}

	public void startTickSound() {

		if (AudioManager.instance.isMusicEnabled) 
		{
			if (!GetComponent<AudioSource> ().isPlaying) {
				GetComponent<AudioSource> ().Play ();
			}
		}

	}

	public void stopTickSound() {

			GetComponent<AudioSource> ().Stop ();
	}
}
