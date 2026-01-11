using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using UnityEngine;

public class Brick_Spawner : MonoBehaviour
{
    public GameObject brick;
    public GameObject specialBrick;
    int maxBricksRows = 4;
    int maxBricksCols = 16;

    const float startingX = -7.3f;
    float currentX = startingX;
    float currentY = 3.5f;

    GameObject[] bricks;
    int totalBricks = 0;

    void addSpecialBricks()
    {
        //randomly replace some bricks with special bricks
        int numSpecialBricks = Random.Range(1, (totalBricks / 6));

        Debug.Log("Adding " + numSpecialBricks + " special bricks.");

        for (int i = 0; i < numSpecialBricks; i++)
        {
            int randBrick = Random.Range(0, totalBricks);

            //save current position of brick
            Vector2 pos = bricks[randBrick].transform.position;

            //remove normal brick
            Destroy(bricks[randBrick]);
            
            //instantiate special brick
            bricks[randBrick] = Instantiate(specialBrick, pos, Quaternion.identity);
        }
    }

    public void CreateBrickLayout()
    {
        for (var i = 0; i < maxBricksRows; i++)
        {
            for (var j = 0; j < maxBricksCols; j++)
            {
                bricks[totalBricks] = Instantiate(brick, new Vector3(currentX, currentY, 0), Quaternion.identity);
                // bricks[totalBricks] = Instantiate(specialBrick, new Vector3(currentX, currentY, 0), Quaternion.identity);
                totalBricks++;
                currentX += 1;
            }
            currentX = startingX;
            currentY -= 0.5F;
        }

        addSpecialBricks();
    }

    public int GetBrickCount()
    {
        return maxBricksRows * maxBricksCols;
    }

    void Start()
    {
        bricks = new GameObject[maxBricksRows * maxBricksCols];
        CreateBrickLayout();
    }
}
