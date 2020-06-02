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


    public void AddPuntos(int puntuacion)
    {
        puntos += puntuacion;                   // Añadimos los puntos al total
        Debug.Log("PUNTUACIÓN: " + puntos);     // Avisamos en consola los puntos que tenemos
        if (theUIManager != null)
            theUIManager.UpdateScore(puntos);   // Actualizamos el UI para que ponga los puntos que tenemos
    } // Método para añadir la puntuacion a la total

    public bool PlayerLoseLife()
    {
        vidas--;                        // Restamos una vida
        theUIManager.LifeLost(vidas);   // Actualizamos el UI para que ponga las vidas que tenemos
        if (vidas == 0 && jugando)      // Si llegamos a tener 0 vidas y seguimos jugando
        {
            LevelFinished(false);       // Llamamos al metodo para saber que hemos acabado perdiendo
        }
        Debug.Log("Vidas: " + vidas);   // Avisamos en consola las vidas que tenemos
        return (vidas > 0);             // Devuelve true siempre que tenga mas de 0 vidas
    } // Método para reducir una vida y saber si estamos vivo

    public void AddBrick()
    {
        if (!jugando) jugando = true;       // Actualizamos que hemos entrado en un nivel asi que si estamos jugando
        brick++;                            // Añadimos un brick
        Debug.Log("Ladrillos: " + brick);   // Avisamos en consola los bricks que tenemos
    } // Método para añadir un brick y saber cuando estamos jugando

    public void BrickDestroyed()
    {
        brick--;                             // Restamos un brick
        Debug.Log("Ladrillos: " + brick);    // Avisamos en consola los bricks que tenemos
        if (brick == 0 && vidas != 0 && jugando) // Si llegamos a 0 bricks, seguimos con vida y estamos jugando
            LevelFinished(true);                 //  Llamamos al metodo para saber que hemos acabado ganando
    } // Método para restar un brick y saber cuando hemos acabado el nivel

    private void LevelFinished(bool playerWins)
    {
        jugando = false;        // Hemos acabado de jugar
        if (playerWins)         // Si hemos pasado el nivel
        {
            if (SceneManager.GetActiveScene().name == "Level1")         // Y estamos en el nivel1
                SceneManager.LoadScene("Level2", LoadSceneMode.Single); // Pasamos al nivel2
            else   // En el caso de estar en el nivel2
            {
                theUIManager.FinishGame(playerWins); // Avisamos al UI de que hemos acabado ganando
                puntos = 0;                          // Actualizamos los puntos a 0
                vidas = 3;                           // Actualizamos las vidas a 3
            }
        }
        else   // Si hemos perdido
        {
            theUIManager.FinishGame(playerWins); // Avisamos al UI de que hemos acabado perdiendo
            puntos = 0;                          // Actualizamos los puntos a 0
            vidas = 3;                           // Actualizamos las vidas a 3
        }
    } // Método para cambiar de nivel o avisar al UI de que hemos acabado

    public bool GetJugando()
    {
        return jugando;
    } // Método para saber si estamos jugando

    public void SetUIManager(UIManager uim) // Comprobar solo un UI y actualizarlo
    {
        theUIManager = uim;
        theUIManager.RemainingLifes(vidas);
        theUIManager.UpdateScore(puntos);
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
    } // Método para cambiar de escena
}
