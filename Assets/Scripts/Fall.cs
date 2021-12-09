using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fall : MonoBehaviour
{
    public playerControllwe thePlayer;

    private Score theScoreManager;

        private void Start()
        {
        theScoreManager = FindObjectOfType<Score>();
        }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            theScoreManager.scoreIncreasing = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            theScoreManager.scoreCount = 0;
            theScoreManager.scoreIncreasing = true;
            hiscore = 0

        }
    }
}
