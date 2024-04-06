using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Spawner : MonoBehaviour
{
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;

    // Update is called once per frame
    void Update()
    {
        spawner();
    }

    void spawner()
    {
        float spawnY = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = UnityEngine.Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector3 position = new Vector3(spawnX, spawnY, 0.0f);
        float asteroidType = UnityEngine.Random.Range(0, 1000);

        switch (asteroidType)
        {
            case 0:
                Instantiate(asteroid1, position, Quaternion.identity);
                break;
            case 1:
                Instantiate(asteroid2, position, Quaternion.identity);
                break;
            case 2:
                Instantiate(asteroid3, position, Quaternion.identity);
                break;
        }

    }
}
