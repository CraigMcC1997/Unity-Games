using UnityEngine;

public class Special_Brick_Controller : MonoBehaviour
{
    public GameObject Balls_Prefab;
    public Paddle_Controller paddleController;

    public void randomPickPowerUp()
    {
        int randPowerUp = Random.Range(0, 3);
        Debug.Log("Picked power up: " + randPowerUp);

        switch (randPowerUp)
        {
            case 0:
                AddBalls();
                break;
            case 1:
                IncreasePaddleSize();
                break;
            case 2:
                decreasePaddleSize();
                break;
            default:
                Debug.Log("No power up selected.");
                break;
        }
    }

    void AddBalls()
    {
        Debug.Log("Adding extra balls!");
        var newBall = Instantiate(Balls_Prefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        newBall.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    void IncreasePaddleSize()
    {
        Debug.Log("Increasing paddle size!");
        paddleController.increasePaddleSize();
    }

    void decreasePaddleSize()
    {
        Debug.Log("Decreasing paddle size!");
        paddleController.decreasePaddleSize();
    }


    void OnDestroy()
    {
        randomPickPowerUp();
    }

}
