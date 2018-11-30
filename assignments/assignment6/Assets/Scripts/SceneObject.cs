using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SceneObject : MonoBehaviour
{
    void Start()
    {
        EventTrigger enterTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry enterEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        enterEntry.callback.AddListener((data) => { OnPointerEnterDelegate(this); });
        enterTrigger.triggers.Add(enterEntry);
    }

    void OnPointerEnterDelegate(SceneObject pointedObject)
    {
        GameController.gameController.TriggerOnSceneObjectPointerEnter(pointedObject);
    }

    public abstract void PerformAction(string action);
}
