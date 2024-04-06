using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_controller : MonoBehaviour
{
    A_Score_Manager score;
    Vector3 direction;
    GameObject spaceship;
    float velocity = 2.0f;
    Vector3 move_obj;

    void Start()
    {
        score = GameObject.Find("Score Manager").GetComponent<A_Score_Manager>();
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("SpaceShip"))
        {
            score.Hit_Ship();
            Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("Wall"))
        {
            Debug.Log("Wall hit");
            Destroy(gameObject);
        }
    }
}
