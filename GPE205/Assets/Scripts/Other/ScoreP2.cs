using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreP2 : MonoBehaviour
{
    public Text playerScore;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.P2 != null)
        {
            playerScore.text = GameManager.instance.P2score.ToString();
        }
    }
}
