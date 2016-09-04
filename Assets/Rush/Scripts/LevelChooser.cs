using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour {

	//Üzerine tıklanan level'a gitme olayı ve geçilen level'ları aktif etme
	// Use this for initialization
	Color dark = new Color (0.4f, 0.4f, 0.4f);
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable() {
		Debug.Log ("Level chooser enable");
		//
		GameObject[] allImages = GameObject.FindGameObjectsWithTag ("LvlImage");
		int currentLevel = PlayerPrefs.GetInt ("level", 0) + 1;//Preferences'ta index olarak tutuyoruz
		Debug.Log(currentLevel);
		int imageLevelNumber;

		for (int i = 0; i < allImages.Length; i++) {

			Image img = allImages [i].GetComponent<Image> ();
			int imageLevel = System.Int32.Parse (img.name); // DİKKAT !! Image ismini inte çeviriyoruz(bug olabilir)
			if (imageLevel > currentLevel) {

				img.color = dark;
				allImages [i].GetComponent<Button> ().enabled = false;
			} else {
				img.color = Color.white;
				allImages [i].GetComponent<Button> ().enabled = true;
			}

		}
	
	}

	public void OnImageClick(int levelNum) {

		 
		LevelManager.instance.setCurrentLevel (levelNum);
		GameController.instance.StartGamePlay (GameController.instance.LastScreen);

	}
}
