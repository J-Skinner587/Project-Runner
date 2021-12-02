using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiscoreCount;

    public float pointspersecond;

    public bool scoreIncreasing;


    private void Start()
    {
      if(PlayerPrefs.GetInt("HighScore") != null)
        {
            hiscoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }
    void Update()
    {

        if (scoreIncreasing)
        {
            scoreCount += pointspersecond * Time.deltaTime;
        }
        if(scoreCount > hiscoreCount)
        {
            hiscoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiscoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round (hiscoreCount);
    }
}
