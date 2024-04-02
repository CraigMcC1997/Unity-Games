using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Controller : MonoBehaviour
{
    float moveSpeed;
    float translation;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            translation = Input.GetAxis("Horizontal") * moveSpeed;
        }

        // Make it move it per second instead of per frame
        translation *= Time.deltaTime;

        // Move translation along the object's y-axis
        transform.Translate(translation, 0, 0);
    }
}
