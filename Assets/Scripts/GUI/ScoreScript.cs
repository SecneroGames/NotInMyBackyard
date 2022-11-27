using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int score;

    //Main Game Score UI 
    [SerializeField] GameObject scoreTextUI;
    private Text scoreText;

    //Game Over ScoreUI
    [SerializeField] GameObject goScoreTextUI;
    private Text goScoreText;

    void Start()
    {
        score = 0;
        scoreText = scoreTextUI.GetComponent<Text>();
        goScoreText = goScoreTextUI.GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        goScoreText.text = scoreText.text;
    }
}
