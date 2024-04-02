using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader_Spawner : MonoBehaviour
{
    public GameObject invader;

    const float startingX = -5.6f;
    float currentX = startingX;
    float currentY = 3.5f;

    const int maxRows = 12;
    const int maxCols = 6;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < maxCols; i++)
        {
            for (var j = 0; j < maxRows; j++)
            {
                Instantiate(invader, new Vector3(currentX * 1.0f, currentY, 0), Quaternion.identity);
                currentX += 1;
            }
            currentX = startingX;
            currentY -= 0.5F;
        }
    }
}
