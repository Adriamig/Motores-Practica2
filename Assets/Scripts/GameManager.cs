using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    UIManager theUIManager;

    public int puntos = 0;
    public int brick = 0;

    private int vidas = 3;
    private bool jugando = true;

    void Awake() // Comprobar que solo hay un GameManager
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        jugando = true;
    }

    public void AddPuntos(int puntuacion)
    {
        puntos += puntuacion;
        Debug.Log("PUNTUACIÓN: " + puntos);
        if (theUIManager != null)
            theUIManager.UpdateScore(puntos);
    }

    public bool PlayerLoseLife()
    {
        vidas--;
        theUIManager.LifeLost(vidas);
        if (vidas == 0)
        {
            LevelFinished(false);
        }
        Debug.Log("Vidas: " + vidas);
        return (vidas > 0);
    }

    public void AddBrick()
    {
        brick++;
        Debug.Log("Ladrillos: " + brick);
    }

    public void BrickDestroyed()
    {
        brick--;
        Debug.Log("Ladrillos: " + brick);

        if (brick == 0 && vidas != 0) LevelFinished(true);
    }

    private void LevelFinished(bool playerWins)
    {
        if (playerWins)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
            else
            {
                theUIManager.FinishGame(playerWins);
                jugando = false;
            }
        }
        else
        {
            theUIManager.FinishGame(playerWins);
            jugando = false;
        }
    }

    public bool GetJugando()
    {
        return jugando;
    }

    public void SetUIManager(UIManager uim) // Comprobar solo un UI y actualizarlo
    {
        theUIManager = uim;
        theUIManager.RemainingLifes(vidas);
        theUIManager.UpdateScore(puntos);
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
        Debug.Log("Actualizado");
    }
}
