using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Spawner : MonoBehaviour
{
    public GameObject brick;
    const int maxBricksRows = 16;
    const int maxBricksCols = 6;
    public int MAX_SCORE = maxBricksRows * maxBricksCols;

    const float startingX = -7.3f;
    float currentX = startingX;
    float currentY = 3.5f;

    void CreateBrickLayout()
    {
        for (var i = 0; i < maxBricksCols; i++)
        {
            for (var j = 0; j < maxBricksRows; j++)
            {
                Instantiate(brick, new Vector3(currentX, currentY, 0), Quaternion.identity);
                currentX += 1;
            }
            currentX = startingX;
            currentY -= 0.5F;
        }
    }

    void Start()
    {
        CreateBrickLayout();
    }

    public int GetMaxScore()
    {
        return MAX_SCORE;
    }
}
