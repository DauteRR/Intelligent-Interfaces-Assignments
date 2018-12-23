using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text compassText;
	public Text accelerometerText;
	public Text gpsText;

	// Use this for initialization
	void Start () {
		StartCoroutine (InitializeCompass ());
	}

	void Update() {
		compassText.text = "Compass: " + Input.compass.trueHeading;
		accelerometerText.text = "Accelerometer:\n" + Input.acceleration;
		gpsText.text = "GPS: " + GetGPSCoordinates();

	}

	string GetGPSCoordinates (){
		string result = "(";

		if (Input.location.status == LocationServiceStatus.Running) {
			result += Input.location.lastData.latitude + ", " + Input.location.lastData.longitude + ", " + Input.location.lastData.altitude;
		}
		return result + ")";
	}

	public IEnumerator InitializeCompass() {
		if (!Input.location.isEnabledByUser) {
			Debug.Log("location disabled by user");
			yield break;
		}

		Input.compass.enabled = true;

		Debug.Log ("Start location service");

		Input.location.Start(10, 0.01f);

		int maxSecondsToWaitForLocation = 20;

		while (Input.location.status == LocationServiceStatus.Initializing &&
			maxSecondsToWaitForLocation > 0) {
			yield return new WaitForSeconds (1);
			maxSecondsToWaitForLocation -= 1;
		}

		if (maxSecondsToWaitForLocation < 1) {
			Debug.Log ("Location service timeout");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("Unable to determine device location");
			yield break;
		}
		Debug.Log ("Location service loaded");
		yield break;
	}
}
