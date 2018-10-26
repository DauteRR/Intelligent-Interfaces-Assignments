using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody rigidBody;

    public float speed;
    public float newMovementWaitMin;
    public float newMovementWaitMax;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(RandomMove());
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(newMovementWaitMin, newMovementWaitMax));
            float moveHorizontal = Random.Range(-1.0f, 1.0f);
            float moveVertical = Random.Range(-1.0f, 1.0f);

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rigidBody.velocity = movement * speed;
        }
    }
}