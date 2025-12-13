using UnityEngine;

public class DontDestroyMe : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Forever");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public enum PongModes
    {
        InfinitePong,
        TennisPong,
        FootballPong
    }

    public static PongModes PongMode = PongModes.InfinitePong;

    public void SetPongMode(PongModes mode)
    {
        PongMode = mode;
    }

}
