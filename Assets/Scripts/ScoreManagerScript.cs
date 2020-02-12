using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public static ScoreManagerScript instance;
    private Text scoreText;
    private int score;
    public GameObject gameOverText;
    private void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        if (instance == null)
        { instance = this; }
    }

    public void SetScore()
    {
        score++;
        scoreText.text = score+"";
    }
    public void GameOverFunction()
    {
        gameOverText.SetActive(true);
    }
}