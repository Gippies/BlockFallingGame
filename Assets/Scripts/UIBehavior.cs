using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{
    PlayerBehavior player;
    bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        player = FindObjectOfType<PlayerBehavior>();
        isGameOver = false;
        player.OnPlayerDeath += GameOver;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameObject.SetActive(true);
    }
}
