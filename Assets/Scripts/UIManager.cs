using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText, finishText;
    public GameObject finishPanel;
    public Image[] life;

    private int numVida = 0;

    void Start()
    {
        finishPanel.SetActive(false);
        GameManager.instance.SetUIManager(this);
        UpdateScore(0);
    }

    public void FinishGame(bool playerWins)
    {
        finishPanel.SetActive(true);
        switch (playerWins)
        {
            case true:
                finishPanel.GetComponent<Image>().color = new Color(255, 255, 0, 0.4f);
                finishText.GetComponent<Text>().text = "Has ganado UwU";
                break;
            case false:
                finishPanel.GetComponent<Image>().color = new Color(170, 0, 255, 0.4f);
                finishText.GetComponent<Text>().text = "Has perdido :'(";
                break;
        }
    }

    public void LifeLost()
    {
        life[numVida].enabled = false;
        numVida++;
    }


    public void UpdateScore(int points)
    {
        scoreText.text = points.ToString();
    }
}
