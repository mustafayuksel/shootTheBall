using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour {

	//Üzerine tıklanan level'a gitme olayı ve geçilen level'ları aktif etme
	// Use this for initialization
	Color dark = new Color (0.2f, 0.2f, 0.2f);
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable() {
		//
		GameObject[] allImages = GameObject.FindGameObjectsWithTag ("LvlImage");
		int currentLevel = PlayerPrefs.GetInt ("level", 0) + 1;//Preferences'ta index olarak tutuyoruz
		int imageLevelNumber;

		for (int i = 0; i < allImages.Length; i++) {

			Image img = allImages [i].GetComponent<Image> ();
			int imageLevel = System.Int32.Parse (img.name); // DİKKAT !! Image ismini inte çeviriyoruz(bug olabilir)
			if (imageLevel > currentLevel) {

				img.color = dark;
			}

		}
	
	}

	public void OnImageClick(int levelNum) {
		Debug.Log ("Clicked:" + levelNum);
	//TO-DO
	//	GamePlay.instance.loadLevel (levelNum);

	}
}
