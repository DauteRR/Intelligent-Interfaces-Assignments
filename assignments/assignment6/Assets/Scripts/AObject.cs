using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AObject : SceneObject
{
	public override void PerformAction(string action)
	{
        if (action.Contains("right"))
        {
            StartCoroutine(SmoothMovement(-1, 1, action));
        }
        else if (action.Contains("left"))
        {
            StartCoroutine(SmoothMovement(1, 1, action));
        }
    }

    IEnumerator SmoothMovement(float direction, float movementTime, string action)
    {
        Debug.Log(action);
        float timePassed = 0;
        while(timePassed < movementTime)
        {
            timePassed += Time.deltaTime;
            transform.position += transform.forward * direction * 0.05f;
            yield return null;
        }
    }
}
