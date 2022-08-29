using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GAMEOVER : MonoBehaviour
{
    [SerializeField] private Text destroyed;
    [SerializeField] private PlanetHP check;
    [SerializeField] private Text highscore;
    [SerializeField] private Text score_ingame;
    private bool pause;
    public int score = 0;

    private void Start()
    {
        highscore.text = "highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        if(check._CurrentHealth <= 0)
        {
            ScoreUpdate();
        }
        score_ingame.text = "score: " + score.ToString();
    }

    public void ScoreUpdate()
    {
        destroyed.text = "score: " + score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscore.text = score.ToString();
        }
    }
}
