using UnityEngine;

public class Special_Brick_Controller : MonoBehaviour
{
    public GameObject Balls_Prefab;
    Paddle_Controller paddleController;

    void Start()
    {
        paddleController = GameObject.Find("paddle").GetComponent<Paddle_Controller>();
    }

    public void randomPickPowerUp()
    {
        int PowerUpsCount = 3;

        int randPowerUp = Random.Range(0, PowerUpsCount);
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
            // case 3:
            //     increaseBallSpeed();
            //     break;
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

    // void increaseBallSpeed()
    // {
    //     Debug.Log("Increasing ball speed!");
    //     var ball = GameObject.Find("Main Ball");
    //     ball.GetComponent<BB_Ball_Controller>().IncreaseSpeed(50.0f);
    // }

    void OnDestroy()
    {
        randomPickPowerUp();
    }

}
