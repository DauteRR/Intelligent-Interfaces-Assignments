using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CObject : MonoBehaviour
{
	void Start ()
	{
        EventTrigger enterTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry enterEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        enterEntry.callback.AddListener((data) => { OnPointerEnterDelegate(); });
        enterTrigger.triggers.Add(enterEntry);

        EventTrigger exitTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry exitEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerExit
        };
        exitEntry.callback.AddListener((data) => { OnPointerExitDelegate(); });
        exitTrigger.triggers.Add(exitEntry);
    }

    void OnPointerEnterDelegate()
    {
        GameController.TriggerOnCObjectPointerEnter();
    }

    void OnPointerExitDelegate()
    {
        GameController.TriggerOnCObjectPointerExit();
    }
}
