using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScorePanel scorePanel;

    public static GameManager instance;
    public static float GameSpeed { get; private set; } = 3f;

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

    private IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(5f);

        GameSpeed += 1;

        StartCoroutine(IncreaseSpeed());
    }
}
