using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text score;
    public Text highScore;
    public Text coin;

    public float scoreCount;
    public float highScoreCount;
    public int coinCount;
    public int totalCoins;

    public float pointsPerSecond;

    public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        if (PlayerPrefs.HasKey("Coins"))
        {
            totalCoins = PlayerPrefs.GetInt("Coins");
            //Debug.Log(totalCoins);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        score.text = "Score: " + Mathf.Round(scoreCount);
        highScore.text = "High Score: " + Mathf.Round(highScoreCount);
        coin.text = "x " + coinCount;
	}

    public void AddScore(int scoreToAdd)
    {
        scoreCount += scoreToAdd;
        coinCount++;
    }
}
