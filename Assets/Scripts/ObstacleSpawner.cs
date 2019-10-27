using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    float randomTimeInterval;
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
            randomTimeInterval = Random.Range(0.1f, 1.0f);
            yield return new WaitForSeconds(randomTimeInterval);
        }
    }

    void SpawnObstacle()
    {
        float randomSize = Random.Range(0.25f, 3.0f);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-screenHalfWidthInWorldlUnits, screenHalfWidthInWorldlUnits), Camera.main.orthographicSize + randomSize, 0.0f);
        Vector3 randomRotation = Vector3.forward * Random.Range(0f, 360f);

        GameObject newObstacle = (GameObject)Instantiate(obstaclePrefab, randomSpawnPosition, Quaternion.Euler(randomRotation));
        newObstacle.transform.localScale = new Vector3(randomSize, randomSize, 1.0f);
        newObstacle.transform.parent = transform;
    }
}
