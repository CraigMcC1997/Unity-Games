using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    float thrust;
    Rigidbody2D m_Rigidbody;
    Score_Manager score;

    public void init()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Set the speed of the GameObject
        thrust = 500.0f;
        score = GameObject.Find("Score Manager").GetComponent<Score_Manager>();
    }

    private void starting_direction()
    {
        float starting_direction_x = Random.Range(1, 10);  // creates a number between 1 and 10
        float starting_direction_y = Random.Range(1, 10);

        if (starting_direction_x % 2 == 0)
        {
            m_Rigidbody.AddForce(transform.right * thrust);
        }
        else
        {
            m_Rigidbody.AddForce(transform.right * -thrust);
        }

        if (starting_direction_y % 2 == 0)
        {
            m_Rigidbody.AddForce(transform.up * thrust);
        }
        else
        {
            m_Rigidbody.AddForce(transform.up * -thrust);
        }
    }

    // from the start of the game, the ball will move to the left`
    public void Start()
    {
        init();
        starting_direction();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetBall();
        }
    }

    // Gets called at the start of the collision
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name == "Wall L")
        {
            resetBall();
            score.RightScored();
        }

        if (target.gameObject.name == "Wall R")
        {
            resetBall();
            score.LeftScored();
        }
    }

    void resetBall()
    {
        //reset the ball
        m_Rigidbody.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        m_Rigidbody.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        thrust = 500.0f;

        starting_direction();
    }
}
