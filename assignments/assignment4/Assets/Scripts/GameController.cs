using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour
{
    public FirstPersonController player;

    [HideInInspector]
    public GameObject[] speedDownModifiers;

    /** Events */
    public delegate void Event();
    public static event Event EventsToHandle;

    /** Delegate patron */
    public delegate void PlayerDelegate(FirstPersonController player);
    public static PlayerDelegate currentPlayerAction;

    /** Singleton patron */
    public static GameController gameController;

	bool isPaused;

    GameObject pauseModeUI;

	void Start()
	{
        speedDownModifiers = GameObject.FindGameObjectsWithTag("SpeedDownModifier");
        pauseModeUI = GameObject.FindGameObjectWithTag("PauseModeUI");
        pauseModeUI.SetActive(false);
        isPaused = false;
    }

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
		if (Input.GetKeyDown("p"))
		{
			if (isPaused) 
			{
				Continue();
			} else 
			{
                Pause();
			}
		}
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


	void Continue()
	{
        pauseModeUI.SetActive(false);
        player.m_MouseLook.SetCursorLock(true);
		player.enabled = true;
		Time.timeScale = 1;
		isPaused = false;
	}

	void Pause()
	{
        pauseModeUI.SetActive(true);
        player.m_MouseLook.SetCursorLock (false);
		player.enabled = false;
		Time.timeScale = 0;
		isPaused = true;
	}
}
