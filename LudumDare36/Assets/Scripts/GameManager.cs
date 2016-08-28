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
    public int HighScore
    {
        get { return PlayerPrefs.GetInt("HighScore"); }
        set
        {
            if (value > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", value);
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
}
