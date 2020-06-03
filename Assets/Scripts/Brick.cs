using UnityEngine;

public class Brick : MonoBehaviour
{
    void Start()
    {
        if(GameManager.instance != null)
        {
            // Llamamos al GameManager para avisar de que se ha añadaido un brick.
            GameManager.instance.AddBrick();
        }
    }

    private void OnDestroy()
    {
        if(GameManager.instance != null)
        {
            // Llamamos al GameManager para decir que se ha destruido un brick.
            // Se activa cuando el GameObject es destruido.
            GameManager.instance.BrickDestroyed();
        }
    } 
}
