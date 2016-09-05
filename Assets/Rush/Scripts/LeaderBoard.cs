using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour {



	public static LeaderBoard instance;

	public Text loginTest;
	private string leaderboardId = "CgkIwtGh4MQEEAIQAg";



	void Awake() {

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ()
			.Build ();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();

		Social.localUser.Authenticate ((bool success) => {
			if(success) {

				loginTest.text = "Login Successful";
			} else {
				loginTest.text = "Login Unsuccesful";
			}
		});
		if (instance == null) {
			instance = this;
			return;
		}
		Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showLeaderBoardUI() {

		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboardId); 

	}
	public void login() {
		if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate ((bool success) => {
				if(success) {

				loginTest.text = "Login Successful";
				} else {
					loginTest.text = "Login Unsuccesful";
				}
			});
		}
	}

	public void postScore() {


		if (Social.localUser.authenticated) {
			int maxScore = PlayerPrefs.GetInt ("level", 0) + 1;
			Social.ReportScore (maxScore, leaderboardId, (bool success) => {

			});
		}
	}
}
