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
        GameManager.instance.SetUIManager(this);            // Actualizamos el UIManager
        volverMenu = finishPanel.transform.Find("ButtonVuelta").GetComponent<Button>(); // Cojo el boton
    }                                                                                   // para cambiar su color

    public void FinishGame(bool playerWins)
    {
        finishPanel.SetActive(true); // Activamos el panel
        if (playerWins) // Si el jugador gana
        {
            finishPanel.GetComponent<Image>().color = new Color(255, 255, 0, 0.3f); // La pantalla se pone de color amarillo
            finishText.GetComponent<Text>().text = "Has\nganado :)";                // Sale un mensaje de victoria
            volverMenu.image.color = new Color(255, 255, 0);                        // El boton se pone amarillo
        }
        else            // En el caso de que no gane
        {
            finishPanel.GetComponent<Image>().color = new Color(170, 0, 255, 0.3f); // La pantalla se pone de color morado
            finishText.GetComponent<Text>().text = "Has\nperdido :'(";              // Sale un mensaje de derrota
            volverMenu.image.color = new Color(170, 0, 255);                        // El boton se pone morado
        }
    }

    public void LifeLost(int numVida)
    {
        life[numVida].enabled = false;
    } // Método para desactivar el sprite de la vida cuando perdemos una

    public void RemainingLifes(int lifes)
    {
        for (int i = 2; i >= lifes; i--)
            LifeLost(i);
    } // Método para actualizar las vidas que tenemos

    public void UpdateScore(int points)
    {
        scoreText.text = points.ToString();
    } // Método para actualizar el texto de los puntos que tenemos
}
