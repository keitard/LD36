using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
    struct Data
    {
        public int currentScore;
        public int currentHighscore;
    }
    Data data;

    public Text scoreText;
    public Text highscoreText;

    public GameObject pauseButton, pauseHUD, gameHUD, mainMenu;

    bool isGamePaused;
    public bool IsGamePaused
    {
        get;
        private set;
    }

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            Pause();
        }

        if(GameManager.Instance.Score != data.currentScore)
        {
            data.currentScore = GameManager.Instance.Score;
            GameManager.Instance.Highscore = data.currentScore;
            scoreText.text = "" + data.currentScore;
        }
        if(GameManager.Instance.Highscore != data.currentHighscore)
        {
            data.currentHighscore = GameManager.Instance.Highscore;
            highscoreText.text = "Highscore: " + data.currentHighscore;
        }

        Time.timeScale = IsGamePaused ? 0 : 1;
    }

    public void Pause()
    {
        Camera.main.GetComponent<BlurOptimized>().enabled = !Camera.main.GetComponent<BlurOptimized>().enabled;
        IsGamePaused = !IsGamePaused;
        pauseHUD.SetActive(!pauseHUD.activeInHierarchy);
        pauseButton.SetActive(!pauseButton.activeInHierarchy);
    }

    public void StartGame()
    {
        gameHUD.SetActive(true);
        mainMenu.SetActive(false);
        Camera.main.transform.DOMoveZ(-5, 1f).SetEase(Ease.InOutExpo);
        Camera.main.DOOrthoSize(15, 0.5f).SetEase(Ease.OutExpo).OnComplete(SetStartGame);
    }

    void SetStartGame()
    {
        GameManager.Instance.IsGameStarted = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
