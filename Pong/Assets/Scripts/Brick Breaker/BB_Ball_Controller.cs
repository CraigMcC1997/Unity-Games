using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Ball_Controller : MonoBehaviour
{
    float thrust;
    Rigidbody2D m_Rigidbody;
    BB_Score_Manager score;

    // Start is called before the first frame update
    public void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Set the speed of the GameObject
        thrust = 400;
        score = GameObject.Find("Score Manager").GetComponent<BB_Score_Manager>();

        m_Rigidbody.AddForce(transform.right * thrust);
        m_Rigidbody.AddForce(transform.up * thrust);
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetBall();
        }

        Debug.Log("Trust: " + thrust.ToString());
    }

    // Gets called at the start of the collision
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name == "Wall B")
        {
            resetBall();
            score.Died();
            Debug.Log("Ball hit the bottom wall");
        }

        if (target.gameObject.name.Contains("brick"))
        {
            Destroy(target.gameObject);
            Debug.Log("Ball hit BRICK");
            score.Scored();
            thrust += 1.0f;
        }
    }

    void resetBall()
    {
        //reset the ball
        m_Rigidbody.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        m_Rigidbody.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        //readd the forces to start the ball moving again
        m_Rigidbody.AddForce(transform.right * thrust);
        m_Rigidbody.AddForce(transform.up * thrust);
    }
}
