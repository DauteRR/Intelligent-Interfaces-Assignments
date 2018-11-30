using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BObject : SceneObject
{
    public override void PerformAction(string action)
    {
        if (action.Contains("turn"))
        {
            StartCoroutine(SmoothTurn(180, 1, action));
        }
    }

    IEnumerator SmoothTurn(float degrees, float turnTime, string action)
    {
        Debug.Log(action);
        float timePassed = 0;
        while (timePassed < turnTime)
        {
            timePassed += Time.deltaTime;
            transform.position += transform.forward * - 1 * 0.01f;
            transform.Rotate(new Vector3(degrees * 0.07f, 0, 0));
            yield return null;
        }
    }
}
