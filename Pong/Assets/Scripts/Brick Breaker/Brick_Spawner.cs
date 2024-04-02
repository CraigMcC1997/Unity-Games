using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Spawner : MonoBehaviour
{
    public GameObject brick;

    const float startingX = -7.3f;
    float currentX = startingX;
    float currentY = 3.5f;

    const int maxBricksRows = 16;
    const int maxBricksCols = 8;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < maxBricksCols; i++)
        {
            for (var j = 0; j < maxBricksRows; j++)
            {
                Instantiate(brick, new Vector3(currentX * 1.0f, currentY, 0), Quaternion.identity);
                currentX += 1;
            }
            currentX = startingX;
            currentY -= 0.5F;
        }
    }
}
