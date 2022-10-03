using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private Text scoreText, gameOverScoreText;
    [SerializeField] private GameObject gamePausedMenu, gameOverMenu;

    public void UpdateScore(int _value)
    {
        scoreText.text = _value.ToString();
    }

    public void ShowGamePausedMenu()
    {
        gamePausedMenu.SetActive(true);
    }

    public void ShowGameOverScreen()
    {
        gameOverMenu.SetActive(true);
        gameOverScoreText.text = "Your score is : " + GameManager.Instance.Score.ToString();
    }


    public void HideGamePausedScreen()
    {
        gamePausedMenu.SetActive(false);
    }

}
