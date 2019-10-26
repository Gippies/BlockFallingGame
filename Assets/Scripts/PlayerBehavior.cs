using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public event Action OnPlayerDeath;

    const float speed = 6f;
    const float screenEdge = 5.5f;

    Vector3 input;
    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        UpdatePosition();
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.tag == "Obstacle")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

    void UpdatePosition()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        playerRigidbody.MovePosition(transform.position + input.normalized * speed * Time.fixedDeltaTime);
        if (transform.position.x > screenEdge)
        {
            playerRigidbody.MovePosition(new Vector3(-transform.position.x + transform.localScale.x, transform.position.y, transform.position.z));
        }
        else if (transform.position.x < -screenEdge)
        {
            playerRigidbody.MovePosition(new Vector3(-transform.position.x - transform.localScale.x, transform.position.y, transform.position.z));
        }
    }
}
