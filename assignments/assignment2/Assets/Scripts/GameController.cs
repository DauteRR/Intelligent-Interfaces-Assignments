using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class GameController : MonoBehaviour
{

    private int redEthanPunctuation = 0;
    private int blueEthanPunctuation = 0;

    public Text redEthanScoreText;
    public Text blueEthanScoreText;
    public float spawnWait;
    public Boundary spawnBoundary;
    public GameObject[] spheres;

    void Start ()
    {
        StartCoroutine(SpawnSpheres());
	}
	
    IEnumerator SpawnSpheres()
    {
        while (true)
        {
            foreach (GameObject sphere in spheres)
            {
                Instantiate(sphere, new Vector3(Random.Range(spawnBoundary.xMin, spawnBoundary.xMax), 0,
                    Random.Range(spawnBoundary.zMin, spawnBoundary.zMax)), Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }

    public void AddScore(int scoreToAdd, string playerTag)
    {
        if (playerTag.Equals("RedEthan"))
        {
            redEthanPunctuation += scoreToAdd;
            UpdateRedEthanScoreText();
        } else if (playerTag.Equals("BlueEthan"))
        {
            blueEthanPunctuation += scoreToAdd;
            UpdateBlueEthanScoreText();
        } else
        {
            Debug.Log("Unknown player: " + playerTag);
        }
    }

    void UpdateRedEthanScoreText()
    {
        redEthanScoreText.text = "Red Ethan: " + redEthanPunctuation;
    }

    void UpdateBlueEthanScoreText()
    {
        blueEthanScoreText.text = "Blue Ethan: " + blueEthanPunctuation;
    }
}
