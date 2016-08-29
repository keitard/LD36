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
    public Text gameOverDataText;

    public GameObject player;
    public GameObject pauseButton, pauseHUD, gameHUD, mainMenu, creditsHUD, gameOverHUD;

    bool isGamePaused;
    public bool IsGamePaused
    {
        get;
        private set;
    }

    void Update()
    {
        if(Input.GetKeyDown("escape") && GameManager.Instance.IsGameStarted)
        {
            Pause();
        }

        //if(Input.GetKeyDown("delete"))
        //{
        //    PlayerPrefs.DeleteAll();
        //}

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

        if(IsGamePaused)
        {
            Camera.main.GetComponent<BlurOptimized>().enabled = true;
            pauseHUD.SetActive(true);
            pauseButton.SetActive(false);
        }
        else
        {
            Camera.main.GetComponent<BlurOptimized>().enabled = false;
            pauseHUD.SetActive(false);
            pauseButton.SetActive(true);
        }

        if(GameManager.Instance.IsGameOver)
        {
            Camera.main.GetComponent<BlurOptimized>().enabled = true;
            gameOverDataText.text = "Your score: " + data.currentScore + "\nHighscore: " + data.currentHighscore;
            GameManager.Instance.IsGameStarted = false;
            player.SetActive(false);
            gameOverHUD.SetActive(true);
            pauseButton.SetActive(false);
        }
        else
        {
            Camera.main.GetComponent<BlurOptimized>().enabled = false;
            gameOverHUD.SetActive(false);
            pauseButton.SetActive(true);
        }
    }

    public void Retry()
    {
        player.SetActive(false);

        GameManager.Instance.IsGameOver = false;
        GameManager.Instance.IsGameStarted = true;
        GameManager.Instance.TimeToIncrementSpawnSpeed = 0f;
        GameManager.Instance.Score = 0;

        TombRaiderSpawner.Instance.spawnTime = 5f;
        TombRaiderSpawner.Instance.spawnSpeed = 1.5f;

        Camera.main.transform.DOMove(new Vector3(0, 15, -5), 1f).SetEase(Ease.InOutExpo);
        Camera.main.transform.DORotate(Vector3.right * 60f, 1f).SetEase(Ease.InOutExpo);
        Camera.main.DOOrthoSize(15, 0.5f).SetEase(Ease.OutExpo);

        player.SetActive(true);
    }

    public void Pause()
    {
        IsGamePaused = !IsGamePaused;
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        Camera.main.transform.DOMoveZ(-5, 1f).SetEase(Ease.InOutExpo);
        Camera.main.DOOrthoSize(12.5f, 0.5f).SetEase(Ease.OutExpo).OnComplete(SetStartGame);
    }

    void SetStartGame()
    {
        gameHUD.SetActive(true);
        GameManager.Instance.IsGameStarted = true;
        player.SetActive(true);
    }

    public void MainMenu()
    {
        gameHUD.SetActive(false);
        pauseHUD.SetActive(false);
        gameOverHUD.SetActive(false);
        IsGamePaused = false;

        GameManager.Instance.IsGameOver = false;
        GameManager.Instance.IsGameStarted = false;
        GameManager.Instance.TimeToIncrementSpawnSpeed = 0f;
        GameManager.Instance.Score = 0;

        TombRaiderSpawner.Instance.spawnTime = 5f;
        TombRaiderSpawner.Instance.spawnSpeed = 1.5f;

        Camera.main.transform.DOMove(new Vector3(0, 15, -6f), 1f).SetEase(Ease.InOutExpo);
        Camera.main.transform.DORotate(Vector3.right * 63.25f, 1f).SetEase(Ease.InOutExpo);
        Camera.main.DOOrthoSize(2, 1f).SetEase(Ease.InOutExpo).OnComplete(RestartGame);
    }

    void RestartGame()
    {
        mainMenu.SetActive(true);
    }

    public void Credits()
    {
        mainMenu.SetActive(!mainMenu.activeInHierarchy);
        creditsHUD.SetActive(!creditsHUD.activeInHierarchy);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
