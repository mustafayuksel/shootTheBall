using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour {



	public static LeaderBoard instance;

	public Text loginTest;
	private string leaderboardId = "CgkIwtGh4MQEEAIQAg";



	void Awake() {

		Social.localUser.Authenticate ((bool success) => {
			
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
		GameCenterPlatform.ShowLeaderboardUI(leaderboardId, TimeScope.AllTime);
		//((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboardId); 

	}
	public void login() {
		if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate ((bool success) => {
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
