using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    UIManager theUIManager;

    public int puntos = 0;
    public int brick = 0;

    private int vidas = 3;

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
        puntos += puntuacion;
        Debug.Log("PUNTUACIÓN: " + puntos);
        if (theUIManager != null)
            theUIManager.UpdateScore(puntos);
    }

    public bool PlayerLoseLife()
    {
        bool vivo = true;
        vidas--;
        theUIManager.LifeLost();
        if (vidas == 0)
        {
            vivo = false;
            theUIManager.FinishGame(vivo);
        }
        Debug.Log("Vidas: " + vidas);
        return vivo;
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
    }

    public bool FinalDeJuego()
    {
        bool ultimoBrick = false;
        if (brick == 0)
        {
            ultimoBrick = true;
            theUIManager.FinishGame(ultimoBrick);
        }
        if (vidas == 0)
            return true;
        return ultimoBrick;
    }

    public void SetUIManager(UIManager uim) // Comprobar solo un UI y actualizarlo
    {
        theUIManager = uim;
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
