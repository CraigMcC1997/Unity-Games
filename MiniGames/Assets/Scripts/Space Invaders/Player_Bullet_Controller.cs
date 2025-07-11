using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    float moveSpeed;
    float translation;
    SI_Score_Manager score;
    SI_Paddle_Controller paddle;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5.0f;
        score = GameObject.Find("Score Manager").GetComponent<SI_Score_Manager>();
        paddle = GameObject.Find("Paddle").GetComponent<SI_Paddle_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        //once the bullet is active, move it up constantly
        if (gameObject.activeSelf)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    // Gets called at the start of the collision
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name.Contains("Invader"))
        {
            Destroy(target.gameObject);
            killBullet();
            score.Killed_Invader();
        }

        if (target.gameObject.name.Contains("Death Wall"))
        {
            killBullet();
        }

        if (target.gameObject.name.Contains("shield_brick"))
        {
            killBullet();
        }
    }

    void killBullet()
    {
        Destroy(gameObject);
        if (paddle.bulletCount >= 0)
        {
            paddle.bulletCount--;
        }
    }
}
