using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Controller2 : MonoBehaviour
{
    float moveSpeed;
    float translation;

    void Start()
    {
        //Set the speed of the GameObject
        moveSpeed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            translation = Input.GetAxis("Vertical") * moveSpeed;
        }

        // Make it move it per second instead of per frame
        translation *= Time.deltaTime;

        // Move translation along the object's y-axis
        transform.Translate(0, translation, 0);
    }

    //// Gets called at the start of the collision
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("RIGHT Entered collision with " + collision.gameObject.name);
    //}
}
