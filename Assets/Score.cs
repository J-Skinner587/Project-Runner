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

    // Update is called once per frame
    void Update()
    {

        if (scoreIncreasing)
        {
            scoreCount += pointspersecond * Time.deltaTime;
        }
        if(scoreCount > hiscoreCount)
        {
            hiscoreCount = scoreCount;
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round (hiscoreCount);

    }
}
