using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Ball_Controller : MonoBehaviour
{
    float thrust;
    Rigidbody2D m_Rigidbody;
    public BB_Score_Manager score;
    public Special_Brick_Controller specialBrickController;
    float x;

    private void rand_starting_direction()
    {
        x = (Random.value < 0.5f ? -1.0f : 1.0f) * thrust;
        m_Rigidbody.AddForce(new Vector2(x, 1.0f * thrust));
    }

    IEnumerator delay_start()
    {
        yield return new WaitForSeconds(0.7f);

        rand_starting_direction();
    }

    // Start is called before the first frame update
    public void Start()
    {
        if (score == null)
        {
            score = GameObject.Find("Score Manager").GetComponent<BB_Score_Manager>();
        }

        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Set the speed of the ball
        thrust = 250.0f;

        //delay the ball before starting the game
        if (gameObject.name.Contains("Main Ball"))
            StartCoroutine(delay_start());
        else
            rand_starting_direction();
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.y < 0 && gameObject.name.Contains("Main Ball"))
        {
            score.Died();
            resetBall();
        }
        else
        if (screenPos.y < 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            resetBall();
        }
    }

    public void IncreaseSpeed(float speed = 5.0f)
    {
        thrust += speed;
        // m_Rigidbody.AddForce(new Vector2(x, 1.0f * thrust));
    }

    // Gets called at the start of the collision
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name.Contains("Special"))
        {
            specialBrickController.spawnPowerUp(target.gameObject.transform.position);
        }

        if (target.gameObject.name.Contains("Brick"))
        {
            score.Scored();
            IncreaseSpeed();
            Destroy(target.gameObject);
        }

    }

    void resetBall()
    {
        //reset the ball
        m_Rigidbody.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        m_Rigidbody.transform.position = new Vector3(0.0f, -2.5f, 0.0f);

        rand_starting_direction();
    }
}
