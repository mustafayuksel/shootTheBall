using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class LeaderBoard : MonoBehaviour {

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
}
