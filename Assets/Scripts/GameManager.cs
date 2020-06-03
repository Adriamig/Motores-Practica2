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

    // Comprobar que solo hay un GameManager.
    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Método para añadir la puntuación a la total.
    public void AddPuntos(int puntuacion)
    {
        // Añadimos los puntos al total.
        puntos += puntuacion;

        // Avisamos en consola los puntos que tenemos.
        Debug.Log("PUNTUACIÓN: " + puntos);

        // Actualizamos el UI para que ponga los puntos que tenemos.
        if (theUIManager != null)
            theUIManager.UpdateScore(puntos);  
    }

    // Método para reducir una vida y saber si estamos vivos.
    public bool PlayerLoseLife()
    {
        // Restamos una vida.
        vidas--;
        if (theUIManager != null)
            // Actualizamos el UI para que ponga las vidas que tenemos.
            theUIManager.LifeLost(vidas);

        // Si llegamos a tener 0 vidas y seguimos jugando,
        if (vidas == 0 && jugando)
        { 
            // llamamos al método para saber que hemos acabado perdiendo.
            LevelFinished(false);      
        }

        // Avisamos en consola de las vidas que tenemos.
        Debug.Log("Vidas: " + vidas);

        // Devuelve true siempre que tenga más de 0 vidas.
        return (vidas > 0);             
    }

    // Método para añadir un brick y saber cuando estamos jugando.
    public void AddBrick()
    {
        // Actualizamos que hemos entrado en un nivel asi que sí estamos jugando.
        if (!jugando) jugando = true;

        // Añadimos un brick.
        brick++;

        // Avisamos en consola los bricks que tenemos.
        Debug.Log("Ladrillos: " + brick);   
    }

    // Método para restar un brick y saber cuando hemos acabado el nivel
    public void BrickDestroyed()
    {
        // Restamos un brick.
        brick--;

        // Avisamos en consola los bricks que tenemos.
        Debug.Log("Ladrillos: " + brick);

        // Si llegamos a 0 bricks, seguimos con vida y estamos jugando,
        if (brick == 0 && jugando)
            // llamamos al método para saber que hemos acabado ganando.
            LevelFinished(true);  
    }

    // Método para cambiar de nivel o avisar al UI de que hemos acabado.
    private void LevelFinished(bool playerWins)
    {
        if (theUIManager != null)
        {
            // Hemos acabado de jugar.
            jugando = false;
            // Si hemos pasado el nivel,
            if (playerWins)
            {
                // y estamos en el nivel1.
                if (SceneManager.GetActiveScene().name == "Level1")

                    // pasamos al nivel2.
                    SceneManager.LoadScene("Level2", LoadSceneMode.Single);

                // En el caso de estar en el nivel2,
                else
                {   // avisamos al UI de que hemos acabado ganando,
                    theUIManager.FinishGame(playerWins);

                    // actualizamos los puntos a 0
                    puntos = 0;

                    // y actualizamos las vidas a 3.
                    vidas = 3;
                }
            }
            // Si hemos perdido,
            else
            {
                // avisamos al UI de que hemos acabado perdiendo,
                theUIManager.FinishGame(playerWins);

                // actualizamos los puntos a 0
                puntos = 0;

                // y actualizamos las vidas a 3.
                vidas = 3;
            }
        }
    }

    // Método para saber si estamos jugando.
    public bool GetJugando()
    {
        return jugando;
    }

    // Comprobar que solo hay un UImanager y actualizarlo.
    public void SetUIManager(UIManager uim) 
    {
        theUIManager = uim;
        theUIManager.RemainingLifes(vidas);
        theUIManager.UpdateScore(puntos);
    }

    // Método para cambiar de escena.
    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
    } 
}
