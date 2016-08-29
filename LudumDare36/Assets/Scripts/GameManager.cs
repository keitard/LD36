using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    int highScore;
    public int Highscore
    {
        get { return PlayerPrefs.GetInt("Highscore"); }
        set
        {
            if (value > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", value);
            }
        }
    }

    float timeToIncrementSpawnSpeed;
    public float TimeToIncrementSpawnSpeed
    {
        get
        {
            return timeToIncrementSpawnSpeed;
        }
        set
        {
            timeToIncrementSpawnSpeed = value;
        }
    }

    public bool IsGameStarted
    {
        get;
        set;
    }
    public bool IsGameOver
    {
        get; set;
    }
}
