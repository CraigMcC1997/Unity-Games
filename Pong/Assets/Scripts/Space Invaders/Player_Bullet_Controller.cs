using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    float moveSpeed;
    float translation;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        moveSpeed = 5.0f;
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
        }

        if (target.gameObject.name.Contains("Death Wall"))
        {
           Destroy(gameObject);
        }

        if (target.gameObject.name.Contains("Shield"))
        {
            Destroy(gameObject);
            //kill player / remove life
        }
    }
}
