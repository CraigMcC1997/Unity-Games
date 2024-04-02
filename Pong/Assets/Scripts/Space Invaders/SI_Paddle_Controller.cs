using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SI_Paddle_Controller : MonoBehaviour
{
    float moveSpeed;
    float translation;

    public GameObject bullet;
    public int bulletCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }

        Debug.Log("Bullet Count: " + bulletCount);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            translation = Input.GetAxis("Horizontal") * moveSpeed;
        }

        // Make it move it per second instead of per frame
        translation *= Time.deltaTime;

        // Move translation along the object's x-axis
        transform.Translate(translation, 0, 0);
    }

    void FireBullet()
    {
        if (bulletCount >= 3)
        {
            return;
        }

        bulletCount++;
        Instantiate(bullet, new Vector3(transform.position.x, (transform.position.y + 0.3f), 0.0f), Quaternion.identity);
    }
}
