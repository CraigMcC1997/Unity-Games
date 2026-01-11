using UnityEngine;

public class Special_Brick_Controller : MonoBehaviour
{
    
    public GameObject powerUp;

    public void spawnPowerUp(Vector2 position)
    {
        Instantiate(powerUp, new Vector3(position.x, position.y, 0), Quaternion.identity);
    }
}
