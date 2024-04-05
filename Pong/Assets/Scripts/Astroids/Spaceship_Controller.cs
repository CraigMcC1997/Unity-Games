using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Controller : MonoBehaviour
{
    float moveSpeed;
    float speed = 1.0f;
    float translation;
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
        FaceMouse();
    }

    void FaceMouse()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = MousePos - transform.position;
        transform.up = direction;
    }
}
