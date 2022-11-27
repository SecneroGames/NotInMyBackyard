using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreScript : MonoBehaviour
{
    [SerializeField] GameObject highScoreTextUI;
    private Text highScoreText;

    void Start()
    {
        highScoreText = highScoreTextUI.GetComponent<Text>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        int score = ScoreScript.score;
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }
}
