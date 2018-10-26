using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    private GameController gameController;

    public int collisionScoreValue;

	void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("Cannot find 'GameController' script");
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("RedEthan") && !other.gameObject.CompareTag("BlueEthan"))
            return;
        gameController.AddScore(collisionScoreValue, other.gameObject.tag);
        Destroy(gameObject);
    }
}
