using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Controller2 : MonoBehaviour
{
    public float moveSpeed;
    float translation;

    void Start()
    {
        //Set the speed of the GameObject
        moveSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //check if player reached screen boundaries
            if(screenPos.y < Screen.height)
                //translation = Input.GetAxis("Vertical") * moveSpeed;
                translation = moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //check if player reached screen boundaries
            if(screenPos.y > 0)
                //translation = Input.GetAxis("Vertical") * moveSpeed;
                translation = -moveSpeed;
        }

        // Make it move it per second instead of per frame
        translation *= Time.deltaTime;

        // Move translation along the object's y-axis
        transform.Translate(0, translation, 0);
    }
}
