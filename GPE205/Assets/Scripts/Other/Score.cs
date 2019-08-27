using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text playerScore;
    public Text highScore;
    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.P1 != null)
        {
            playerScore.text = GameManager.instance.P1score.ToString();
            if(GameManager.instance.P1score > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", GameManager.instance.P1score);
                highScore.text = GameManager.instance.P1score.ToString();
            }
        }
    }
}
