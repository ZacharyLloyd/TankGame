using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text playerScore;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.P1 != null)
        {
            playerScore.text = GameManager.instance.P1score.ToString(); 
        }
        if (GameManager.instance.P2 != null)
        {
            playerScore.text = GameManager.instance.P2score.ToString();
        }
    }
}
