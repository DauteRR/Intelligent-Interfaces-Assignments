using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpeedDownScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.currentPlayerAction = SpeedDown;
        }
    }

    void SpeedDown(FirstPersonController player)
    {
        player.m_JumpSpeed *= 0.75f;
        player.m_WalkSpeed *= 0.75f;
        player.m_RunSpeed *= 0.75f;

        foreach (GameObject speedDown in GameController.gameController.speedDownModifiers)
        {
            speedDown.transform.position = new Vector3(
                speedDown.transform.position.x, speedDown.transform.position.y + 0.5f, speedDown.transform.position.z);
        }
    }
}
