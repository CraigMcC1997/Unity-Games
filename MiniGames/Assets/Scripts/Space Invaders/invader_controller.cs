using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invader_controller : MonoBehaviour
{
    public GameObject bullet;

    float moveX = 3f;
    float translation;

    void randomly_shoot_bullet()
    {
        float value = Random.Range(1, 5000);

        if (value == 364)
        {
            //dont shoot if paused
            if (Time.timeScale != 0)
                Instantiate(bullet, new Vector3(transform.position.x, (transform.position.y - 0.3f), 0.0f), Quaternion.identity);
        }
    }

    void move_invader()
    {
        translation = (moveX * Time.deltaTime);
        transform.Translate(translation, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        move_invader();
        randomly_shoot_bullet();
    }

    // Gets called at the start of the collision
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name.Contains("Buffer"))
        {
            moveX *= -1;
            transform.position = new Vector3(transform.position.x, (transform.position.y - 0.3f), 0);
        }

        if (target.gameObject.name.Contains("Paddle"))
        {
            //TODO: KILL PLAYER / END THE GAME
            Destroy(target.gameObject);
        }
    }
}
