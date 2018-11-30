using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CObject : SceneObject
{
    public override void PerformAction(string action)
    {
        if (action.Contains("grow up"))
        {
            StartCoroutine(SmoothGrow(1, action));
        }
    }

    IEnumerator SmoothGrow(float growTime, string action)
    {
        Debug.Log(action);
        float timePassed = 0;
        while (timePassed < growTime)
        {
            timePassed += Time.deltaTime;
            transform.localScale *= 1.01f;
            yield return null;
        }
    }
}
