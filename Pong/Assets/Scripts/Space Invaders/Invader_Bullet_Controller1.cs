using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader_Bullet_Controller : MonoBehaviour
{
    float moveSpeed;
    float translation;
    SI_Score_Manager score;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5.0f;
        score = GameObject.Find("Score Manager").GetComponent<SI_Score_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //once the bullet is active, move it down constantly
        if (gameObject.activeSelf)
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    // Gets called at the start of the collision
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name.Contains("Paddle"))
        {
            //TODO: LOSE A LIFE
            Destroy(gameObject);
            score.Hit_Paddle();
        }

        if (target.gameObject.name.Contains("shield_brick"))
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }

        if (target.gameObject.name.Contains("Death Wall"))
        {
            Destroy(gameObject);
        }

        if (target.gameObject.name.Contains("Invader"))
        {
            Destroy(gameObject);
            //kill player / remove life
        }
    }
}
