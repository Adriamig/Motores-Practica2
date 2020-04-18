using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    UIManager theUIManager;

    public int puntos = 0;
    private int vidas = 3;
    public int brick = 0;

    void Awake() // Comprobar que solo hay un GameManager
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else Destroy(this.gameObject);
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
        if (vidas == 0) vivo = false;
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

    public void SetUIManager(UIManager uim) // Comprobar solo un UI y actualizarlo
    {
        theUIManager = uim;
    }
}
