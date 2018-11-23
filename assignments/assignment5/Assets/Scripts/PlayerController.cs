using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerPower = 0;

    public void IncrementPlayerPower()
    {
        playerPower += 1;
        Debug.Log("Player power = " + playerPower);
    }

    public void DecrementPlayerPower()
    {
        if (playerPower > 0)
            playerPower -= 1;
        Debug.Log("Player power = " + playerPower);
    }
}
