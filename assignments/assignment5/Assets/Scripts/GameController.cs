using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public delegate void OnObjectPointerEvent();

    public static event OnObjectPointerEvent OnCObjectPointerEnter;
    public static event OnObjectPointerEvent OnCObjectPointerExit;

    static public void DestroyClickedAObject(GameObject clickedAObject)
    {
        PlayerController player = Object.FindObjectOfType<PlayerController>();
        if (player.playerPower > 0)
        {
            DestroyObject(clickedAObject);
            player.DecrementPlayerPower();
        }
    }

    static public void TriggerOnCObjectPointerEnter()
    {
        OnCObjectPointerEnter();
    }

    static public void TriggerOnCObjectPointerExit()
    {
        OnCObjectPointerExit();
    }
}
