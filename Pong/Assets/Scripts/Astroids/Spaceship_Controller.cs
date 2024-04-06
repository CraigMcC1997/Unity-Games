using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Controller : MonoBehaviour
{
    float moveSpeed;
    float translationX;
    float translationY;
    Vector3 MousePos;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //FaceMouse();
        move();
    }

    void move()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            translationY = Input.GetAxis("Vertical") * moveSpeed;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            translationX = Input.GetAxis("Horizontal") * moveSpeed;
        }

        // Make it move it per second instead of per frame
        translationX *= Time.deltaTime;
        translationY *= Time.deltaTime;

        // Move translation
        transform.Translate(0, translationY, 0);
        transform.Translate(translationX, 0, 0);
    }

    void FaceMouse()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = MousePos - transform.position;
        transform.up = direction;
    }
}
