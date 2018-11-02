using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private bool lightOn = true;

    private void Start()
    {
        GameController.EventsToHandle += ToggleLight;
    }

    void ToggleLight()
    {
        lightOn = !lightOn;
        gameObject.GetComponent<Light>().enabled = lightOn;
    }
}
