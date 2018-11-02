using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLightIntensity : MonoBehaviour {

	public Slider slider;
	public float minDeltaSize = 0.0f;
	public float maxDeltaSize = 10.0f;

	void Start()
	{
		slider.minValue = minDeltaSize;
		slider.maxValue = maxDeltaSize;
		slider.onValueChanged.AddListener(OnIntensityUpdate);
	}

	private void OnIntensityUpdate(float deltaSize)
	{
		GetComponent<Light> ().intensity = deltaSize;
	}
}
