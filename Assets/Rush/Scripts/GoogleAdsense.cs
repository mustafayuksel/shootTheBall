using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class GoogleAdsense : MonoBehaviour {

	// Use this for initialization

	public static GoogleAdsense instance;
    InterstitialAd interstitial;

	void Awake() {

		requestInterstitialAd ();
		if (instance == null) {
			instance = this;
			return;
		}

		Destroy (this.gameObject);
	}

	public void requestInterstitialAd() {

		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-1847727001534987/8616601751";
		#else 
		string adUnitId = "unexpected";
		#endif

		interstitial = new InterstitialAd (adUnitId);
		AdRequest.Builder b = new AdRequest.Builder ();
		AdRequest request = b.Build ();
		interstitial.LoadAd (request);
	
	}

	public void showInterstitialAd() {

		if (interstitial.IsLoaded ()) {
			interstitial.Show ();
			requestInterstitialAd ();
		}
	}

	public bool isReady() {
		return interstitial.IsLoaded ();
	}



}
