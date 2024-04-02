using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invader_controller : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        float value = Random.Range(1, 5000);

        Debug.Log(value);

        if (value == 364)
        {
            Instantiate(bullet, new Vector3(transform.position.x, (transform.position.y - 0.3f), 0.0f), Quaternion.identity);
        }
    }
}
