using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Image[] life;

    private int numVida = 0;

    void Start()
    {
        GameManager.instance.SetUIManager(this);
        UpdateScore(0);
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
