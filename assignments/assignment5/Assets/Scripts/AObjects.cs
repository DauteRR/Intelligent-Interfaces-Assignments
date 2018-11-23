using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AObjects : MonoBehaviour
{

    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick
        };
        entry.callback.AddListener((data) => { OnPointerClickDelegate(gameObject); });
        trigger.triggers.Add(entry);
    }

    void OnPointerClickDelegate(GameObject aObject)
    {
        GameController.DestroyClickedAObject(aObject);
    }
}
