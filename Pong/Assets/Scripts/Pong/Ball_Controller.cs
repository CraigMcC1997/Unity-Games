using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    Score_Manager score;
    AudioSource Aud_bounce;
    AudioSource Aud_score;
    float thrust;
    const float BALL_VELOCITY = 300.0f;
    

    private void rand_starting_direction()
    {
        float x = (Random.value < 0.5f ? -1.0f : 1.0f) * thrust;
        float y = (Random.value < 0.5f ? -1.0f : 1.0f) * thrust;

        m_Rigidbody.AddForce(new Vector2(x,y));
    }

    //Wait, then give the ball a velocity & direction
    IEnumerator delay_start()
    {
        yield return new WaitForSeconds(0.7f);

        thrust = BALL_VELOCITY;
        rand_starting_direction();
    }

    void resetBall()
    {
        //reset ball position, velocity and direction (pause ball)
        m_Rigidbody.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        m_Rigidbody.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        thrust = 0.0f;

        //delay the ball before starting the game
        StartCoroutine(delay_start());
    }

    // from the start of the game, the ball will move to the left`
    public void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();

        //Fetch the Score Manager component
        score = GameObject.Find("Score Manager").GetComponent<Score_Manager>();

        AudioSource[] audios = GetComponents<AudioSource>();
        Aud_bounce = audios[0];
        Aud_score = audios[1];

        //delay the ball before starting the game
        StartCoroutine(delay_start());
    }

    // Gets called at the start of the collision
    void OnCollisionEnter2D(Collision2D target)
    {
        if ((target.gameObject.name == "Paddle - left")
            || (target.gameObject.name == "Paddle - right")
            || (target.gameObject.name == "Wall T")
            || (target.gameObject.name == "Wall B"))
        {
            Aud_bounce.Play(0);
            thrust += 5f;
            m_Rigidbody.AddForce(m_Rigidbody.linearVelocity.normalized * thrust * Time.deltaTime);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPos.x < 0)
        {
            Aud_score.Play(0);
            resetBall();
            score.RightScored();
        }

        if(screenPos.x > Screen.width)
        {
            Aud_score.Play(0);
            resetBall();
            score.LeftScored();
        }
    }
}
