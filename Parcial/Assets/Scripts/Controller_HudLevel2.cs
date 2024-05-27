using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_HudLevel2 : MonoBehaviour
{
    public Text gameOverText;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (GameManagerLevel2.gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over" ;
            gameOverText.gameObject.SetActive(true);
        }
        if (GameManagerLevel2.winCondition)
        {
            Time.timeScale = 0;
            gameOverText.text = "You Win";
            gameOverText.gameObject.SetActive(true);
        }
    }
}
