using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameController : MonoBehaviour
{
    private static System.Random randomNumberGenerator;
    private static ChatBotController chatBotController;

    private static readonly string[] aObjectsActions = { "Out of my way", "Excuse me, can you move a little bit", "Move out of my way", "You are on my way" };
    private static readonly string[] bObjectsActions = { "There is something behind you", "Look behind you" };
    private static readonly string[] cObjectsActions = { "Can you reach that point at the top?" };

    private static string response;
    private static SceneObject pointedObject;

    public static GameController gameController;

    public void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
            DontDestroyOnLoad(this);
        }
        else if (this != gameController)
        {
            Destroy(gameObject);
        }
        randomNumberGenerator = new System.Random();
        chatBotController = UnityEngine.Object.FindObjectOfType<ChatBotController>();
    }

    private void Update()
    {
        if (response != null)
        {
            pointedObject.PerformAction(response);
            response = null;
            pointedObject = null;
        }
    }

    public void TriggerOnSceneObjectPointerEnter(SceneObject pointedObject)
    {
        GameController.pointedObject = pointedObject;
        Thread requestThread = new Thread(RequestResponse);
        requestThread.Start();
    }

    public void RequestResponse()
    {
        string[] sceneObjectsActions;
        if (pointedObject is AObject)
        {
            sceneObjectsActions = aObjectsActions;
        }
        else if (pointedObject is BObject)
        {
            sceneObjectsActions = bObjectsActions;
        }
        else
        {
            sceneObjectsActions = cObjectsActions;
        }
        string action = sceneObjectsActions[randomNumberGenerator.Next(0, sceneObjectsActions.Length)];
        Thread.BeginCriticalRegion();
        response = chatBotController.SendText(action);
        Thread.EndCriticalRegion();
        Debug.Log(action);
    }
}