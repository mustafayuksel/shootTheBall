using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class LeaderBoard : MonoBehaviour {



	public static LeaderBoard instance;


	void Awake() {
		if (instance == null) {
			instance = this;
			return;
		}
		Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
	
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ()
			.EnableSavedGames ().Build ();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate ((bool success) => {

			if(success) {
			Debug.Log("Logged In");
			Social.ShowLeaderboardUI ();
			}
		});

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void postScore() {

		int maxScore = PlayerPrefs.GetInt ("level", 0) + 1;
		Social.ReportScore (maxScore,"CgkIt6iX3v4VEAIQAA",(bool success)=> {
			Debug.Log("Score is post");
		});

	}
}
