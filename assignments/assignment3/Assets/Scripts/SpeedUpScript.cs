using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpeedUpScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.currentPlayerAction = SpeedUp;
        }
    }

    void SpeedUp(FirstPersonController player)
    {
        player.m_JumpSpeed *= 1.5f;
        player.m_WalkSpeed *= 1.5f;
        player.m_RunSpeed *= 1.5f;
    }
}
