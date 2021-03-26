using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ScorePanel scorePanel;
    public GameObject gameOverPanel;

    public static GameManager instance;
    public static float GameSpeed { get; private set; }
    public static bool IsGameOver { get; private set; }

    private int score;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = false;
        score = 0;

        Time.timeScale = 1;
        GameSpeed = 3f;

        StartCoroutine(IncreaseSpeed());
    }

    public void UpdateScore(int points)
    {
        if(!IsGameOver)
        {
            score += points;
            scorePanel.ScoreToSprite(score);
        }
    }

    private IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(1f);

        GameSpeed += 0.25f;

        StartCoroutine(IncreaseSpeed());
    }

    public void GameOver()
    {
        IsGameOver = true;

        StartCoroutine(Reload());

        Camera.main.gameObject.GetComponent<AudioSource>().pitch = 0.5f;
        Time.timeScale = 0.25f;

        gameOverPanel.SetActive(true);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }
}
