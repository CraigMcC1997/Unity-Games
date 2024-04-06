using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_controller : MonoBehaviour
{
    Vector3 direction;
    GameObject spaceship;
    float velocity = 2.0f;
    Vector3 move_obj;

    void Start()
    {
        spaceship = GameObject.Find("SpaceShip");

        //give the asteroid a starting direction to move towards the spaceship
        direction = (spaceship.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        move_obj = (direction * Time.deltaTime) * velocity;
        //allow the asteroid to keep moving along the direction
        transform.Translate(move_obj);
    }
}
