using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controller : MonoBehaviour
{
    A_Score_Manager score;
    Vector3 mousePos;
    Rigidbody2D rigidbody;
    public float force = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score Manager").GetComponent<A_Score_Manager>();
        rigidbody = GetComponent<Rigidbody2D>();

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 rotate = transform.position - mousePos;
        rigidbody.velocity = new Vector2(dir.x, dir.y).normalized * force;
        float rot_z = Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Asteroid"))
        {
            score.Destroyed_Asteroid();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("Wall"))
        {
            Debug.Log("Wall hit");
            Destroy(gameObject);
        }
    }
}
