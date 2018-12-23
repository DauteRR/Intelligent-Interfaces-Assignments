using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    void Start() {
        WebCamTexture webcam = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = webcam;
        webcam.Play();
    }
}
