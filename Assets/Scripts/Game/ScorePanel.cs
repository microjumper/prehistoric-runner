using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [Header("Index and number must be the same")]
    public Sprite[] numbers;
    public Image[] digits;

    private Dictionary<char, Sprite> dictionary;

    void Start()
    {
        dictionary = new Dictionary<char, Sprite>();

        string keys = "0123456789";
        for (int i = 0; i < keys.Length; i++)
        {
            dictionary.Add(keys[i], numbers[i]);
        }
    }

    public void ScoreToSprite(int score)
    {
        string scoreString = score.ToString();

        if (scoreString.Length < digits.Length)
        {
            for (int i = 0; i < scoreString.Length; i++)
            {
                digits[digits.Length - scoreString.Length + i].sprite = dictionary[scoreString[i]];
            }
        }
    }
}
