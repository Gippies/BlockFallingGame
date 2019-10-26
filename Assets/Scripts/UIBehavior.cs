using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{
    public GameObject playerPrefab;

    bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        gameObject.SetActive(false);

        PlayerBehavior playerBehavior = FindObjectOfType<PlayerBehavior>();
        playerBehavior.OnPlayerDeath += GameOver;
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }

    void ResetGame()
    {
        isGameOver = false;
        gameObject.SetActive(false);

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
        gameObject.SetActive(true);
    }
}
