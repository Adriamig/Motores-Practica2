using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float puntos = 0;
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

    public void AddPuntos(float puntuacion)
    {
        puntos += puntuacion;
        Debug.Log("PUNTUACIÓN: " + puntos);
    }

    public bool PlayerLoseLife()
    {
        bool vivo = true;
        vidas--;
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
}
