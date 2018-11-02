using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSize : MonoBehaviour {

	public Slider slider;
	public float minDeltaSize = 0.2f;
	public float maxDeltaSize = 1.2f;

	void Start()
	{
		slider.minValue = minDeltaSize;
		slider.maxValue = maxDeltaSize;
		slider.onValueChanged.AddListener(OnIntensityUpdate);
	}

	private void OnIntensityUpdate(float deltaSize)
	{
		transform.localScale = new Vector3(deltaSize, deltaSize, deltaSize);
	}
}
