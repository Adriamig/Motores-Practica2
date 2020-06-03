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
        // Actualizamos el UIManager.
        GameManager.instance.SetUIManager(this);

        if(finishPanel != null)
            // Cojo el botón para cambiar su color.
            volverMenu = finishPanel.transform.Find("ButtonVuelta").GetComponent<Button>(); 
    }                                                                                   

    public void FinishGame(bool playerWins)
    {
        if(finishPanel != null)
        {
            // Activamos el panel.
            finishPanel.SetActive(true);

            // Si el jugador gana,
            if (playerWins)
            {
                // la pantalla se pone de color amarillo,ç
                finishPanel.GetComponent<Image>().color = new Color(255, 255, 0, 0.3f);

                // sale un mensaje de victoria
                finishText.GetComponent<Text>().text = "Has\nganado :)";

                // y el botón se pone amarillo.
                volverMenu.image.color = new Color(255, 255, 0);
            }
            // En el caso de que no gane,
            else
            {
                // la pantalla se pone de color morado, 
                finishPanel.GetComponent<Image>().color = new Color(170, 0, 255, 0.3f);

                // sale un mensaje de derrota
                finishText.GetComponent<Text>().text = "Has\nperdido :'(";

                // y el botón se pone morado.
                volverMenu.image.color = new Color(170, 0, 255);
            }
        }
    }

    // Método para desactivar el sprite de la vida cuando perdemos una.
    public void LifeLost(int numVida)
    {
        life[numVida].enabled = false;
    }

    // Método para actualizar las vidas que tenemos.
    public void RemainingLifes(int lifes)
    {
        for (int i = 2; i >= lifes; i--)
            LifeLost(i);
    }

    // Método para actualizar el texto de los puntos que tenemos.
    public void UpdateScore(int points)
    {
        scoreText.text = points.ToString();
    } 
}
