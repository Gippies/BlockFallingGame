using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    const float maxSpawnTime = 0.5f;
    const float minSpawnTime = 0.01f;

    float spawnTimeInterval;
    float screenHalfWidthInWorldlUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidthInWorldlUnits = Camera.main.aspect * Camera.main.orthographicSize;
        StartCoroutine(ContinuouslySpawnObstacles());
    }

    IEnumerator ContinuouslySpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            spawnTimeInterval = Mathf.Lerp(maxSpawnTime, minSpawnTime, Difficulty.GetDifficultyPercent());
            yield return new WaitForSeconds(spawnTimeInterval);
        }
    }

    void SpawnObstacle()
    {
        float randomSize = Random.Range(0.25f, 3.0f);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-screenHalfWidthInWorldlUnits, screenHalfWidthInWorldlUnits), Camera.main.orthographicSize + randomSize, 0.0f);
        Vector3 randomRotation = Vector3.forward * Random.Range(-15f, 15f);

        GameObject newObstacle = (GameObject)Instantiate(obstaclePrefab, randomSpawnPosition, Quaternion.Euler(randomRotation));
        newObstacle.transform.localScale = new Vector3(randomSize, randomSize, 1.0f);
        newObstacle.transform.parent = transform;
    }
}
