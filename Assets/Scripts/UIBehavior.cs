using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{
    public GameObject playerPrefab;

    Canvas uiCanvas;
    bool isGameOver;
    float timeScore;
    Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        uiCanvas = gameObject.GetComponent<Canvas>();
        timeText = gameObject.transform.Find("TimeText").GetComponent<Text>();

        isGameOver = false;
        uiCanvas.enabled = false;
        timeScore = 0.0f;

        PlayerBehavior playerBehavior = FindObjectOfType<PlayerBehavior>();
        playerBehavior.OnPlayerDeath += GameOver;
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
        if (!isGameOver)
        {
            timeScore += Time.deltaTime;
        }
    }

    void ResetGame()
    {
        isGameOver = false;
        uiCanvas.enabled = false;
        timeScore = 0.0f;

        DeleteObstacles();
        SpawnPlayer();
    }

    void DeleteObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
    }

    void SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(0f, -4f, 0f);
        GameObject newPlayer = Instantiate(playerPrefab, spawnPosition, Quaternion.Euler(Vector3.zero));
        newPlayer.GetComponent<PlayerBehavior>().OnPlayerDeath += GameOver;
    }

    public void GameOver()
    {
        isGameOver = true;
        uiCanvas.enabled = true;
        int roundedTimeScore = Mathf.RoundToInt(timeScore);
        timeText.text = "You Survived " + roundedTimeScore + " Seconds";
    }
}
