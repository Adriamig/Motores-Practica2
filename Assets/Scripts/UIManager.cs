using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText, finishText;
    public GameObject finishPanel;
    public Button volverMenu;
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
        if (playerWins)
        {
            finishPanel.GetComponent<Image>().color = new Color(255, 255, 0, 0.3f);
            finishText.GetComponent<Text>().text = "Has\nganado :)";
            volverMenu.GetComponent<Button>().image.color = new Color(255, 255, 0);
        }
        else
        {
            finishPanel.GetComponent<Image>().color = new Color(170, 0, 255, 0.3f);
            finishText.GetComponent<Text>().text = "Has\nperdido :'(";
            volverMenu.GetComponent<Button>().image.color = new Color(170, 0, 255);
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
