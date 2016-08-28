using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    static GUIManager instance;
    public static GUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GUIManager>();
            }
            return instance;
        }
    }

    public Text scoreText;
    public Text highScoreText;

    struct Data
    {
        public int currentScore;
        public int currentHighScore;
    }
    Data data;

    void Update()
    {
        if(GameManager.Instance.Score != data.currentScore)
        {
            data.currentScore = GameManager.Instance.Score;
            GameManager.Instance.HighScore = data.currentScore;
            scoreText.text = "" + data.currentScore;
        }
        if(GameManager.Instance.HighScore != data.currentHighScore)
        {
            data.currentHighScore = GameManager.Instance.HighScore;
            highScoreText.text = "High Score: " + data.currentHighScore;
        }
    }
}
