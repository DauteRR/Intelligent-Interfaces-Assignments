using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensor : MonoBehaviour
{

    void OnCollisionEnter(Collision collisionInfo)
    {
        //print("New collision with " + collisionInfo.transform.name);
        if (collisionInfo.gameObject.CompareTag("RedEthan"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        } else if (collisionInfo.gameObject.CompareTag("BlueEthan"))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (collisionInfo.gameObject.CompareTag("MovingSphere"))
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (collisionInfo.gameObject.CompareTag("StaticSphere"))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        print("In collision with " + collisionInfo.transform.name);
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        print("No longer in contact with " + collisionInfo.transform.name);
    }
}
