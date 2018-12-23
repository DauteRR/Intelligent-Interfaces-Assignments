using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour {

	public void ToggleBackgroundOpacity() {
        Color backgroundColor = GetComponent<Image>().color;
        Debug.Log(backgroundColor);
        if (backgroundColor.a == 1) {
            backgroundColor.a = 0;
        } else {
            backgroundColor.a = 1;
        }
        GetComponent<Image>().color = backgroundColor;
    }
}
