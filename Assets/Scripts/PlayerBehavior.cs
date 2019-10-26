using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    const float speed = 6f;

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
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        playerRigidbody.MovePosition(transform.position + input.normalized * speed * Time.fixedDeltaTime);
    }
}
