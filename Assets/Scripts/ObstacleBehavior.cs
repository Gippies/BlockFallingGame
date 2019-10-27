using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    const float speed = 7f;

    float lowerBound;

    void Start()
    {
        lowerBound = -Camera.main.orthographicSize * 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
