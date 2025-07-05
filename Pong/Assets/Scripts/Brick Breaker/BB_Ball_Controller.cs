using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Ball_Controller : MonoBehaviour
{
    float thrust;
    Rigidbody2D m_Rigidbody;
    BB_Score_Manager score;
    float x;

    // Start is called before the first frame update
    public void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Set the speed of the ball
        thrust = 250.0f;

        score = GameObject.Find("Score Manager").GetComponent<BB_Score_Manager>();

        x = (Random.value < 0.5f ? -1.0f : 1.0f) * thrust;
        m_Rigidbody.AddForce(new Vector2(x, 1.0f * thrust));
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPos.y < 0)
        {
            score.Died();
            resetBall();
        }

        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     resetBall();
        // }
    }

    // Gets called at the start of the collision
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name.Contains("brick"))
        {
            Destroy(target.gameObject);
            score.Scored();
            thrust += 1.0f;
        }
    }

    void resetBall()
    {
        //reset the ball
        m_Rigidbody.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        m_Rigidbody.transform.position = new Vector3(0.0f, -2.5f, 0.0f);

        x = (Random.value < 0.5f ? -1.0f : 1.0f) * thrust;
        m_Rigidbody.AddForce(new Vector2(x, 1.0f * thrust));
    }
}
