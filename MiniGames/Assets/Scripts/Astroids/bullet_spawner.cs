using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_spawner : MonoBehaviour
{
    public GameObject bullet;
    Rigidbody m_Rigidbody;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    m_Rigidbody = bullet.GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Mouse0))
    //        //FireBullet();
    //}

    //void FaceMouse()
    //{
    //    Vector3 MousePos = Input.mousePosition;
    //    MousePos = Camera.main.ScreenToWorldPoint(MousePos);

    //    Vector2 direction = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);

    //    transform.up = direction;
    //}

    //void FireBullet()
    //{
    //    //FaceMouse();
    //    Vector3 position = new Vector3((transform.position.x * transform.rotation.x), (transform.position.y * transform.rotation.y), 0.0f);
    //    Instantiate(bullet, position, transform.rotation);
    //}
}
