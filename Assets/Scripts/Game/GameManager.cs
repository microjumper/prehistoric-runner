using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScorePanel scorePanel;

    public static GameManager instance;
    public static float GameSpeed { get; private set; } = 2.5f;

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
        score = 0;

        StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int points)
    {
        score += points;
        scorePanel.ScoreToSprite(score);
    }

    private IEnumerator IncreaseSpeed() // increment speed every 20 seconds
    {
        yield return new WaitForSeconds(5f);

        GameSpeed += 0.5f;

        StartCoroutine(IncreaseSpeed());
    }
}
