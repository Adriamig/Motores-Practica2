using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText, finishText;
    public GameObject finishPanel;
    public Image[] life;

    private Button volverMenu;

    void Start()
    {
        GameManager.instance.SetUIManager(this);
        volverMenu = finishPanel.transform.Find("BotonMenu").GetComponent<Button>();
    }

    public void FinishGame(bool playerWins)
    {
        finishPanel.SetActive(true);
        if (playerWins)
        {
            finishPanel.GetComponent<Image>().color = new Color(255, 255, 0, 0.3f);
            finishText.GetComponent<Text>().text = "Has\nganado :)";
            volverMenu.image.color = new Color(255, 255, 0);
        }
        else
        {
            finishPanel.GetComponent<Image>().color = new Color(170, 0, 255, 0.3f);
            finishText.GetComponent<Text>().text = "Has\nperdido :'(";
            volverMenu.image.color = new Color(170, 0, 255);
        }
    }

    public void LifeLost(int numVida)
    {
        life[numVida].enabled = false;
    }

    public void RemainingLifes(int lifes)
    {
        for (int i = 2; i >= lifes; i--)
            LifeLost(i);
    }

    public void UpdateScore(int points)
    {
        scoreText.text = points.ToString();
    }
}
