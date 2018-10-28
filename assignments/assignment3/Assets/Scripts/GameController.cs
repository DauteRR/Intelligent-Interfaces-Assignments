using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour
{
    public FirstPersonController player;

    public GameObject[] speedDownModifiers;

    /** Events */
    public delegate void Event();
    public static event Event EventsToHandle;

    /** Delegate patron */
    public delegate void PlayerDelegate(FirstPersonController player);
    public static PlayerDelegate currentPlayerAction;

    /** Singleton patron */
    public static GameController gameController;

    void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
            DontDestroyOnLoad(this);
        } else if (this != gameController)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            EventsToHandle();
        }
        if (currentPlayerAction != null)
        {
            currentPlayerAction(player);
            currentPlayerAction = null;
        }
    }
}
