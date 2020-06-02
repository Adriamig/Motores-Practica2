using UnityEngine;

public class Brick : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.AddBrick(); // Llamamos al GameManager para avisarque se ha añadaido un brick
    }

    private void OnDestroy()
    {
        GameManager.instance.BrickDestroyed(); // LLamamos al GamManager para decir que se ha destruido un brick
    } // Se activa cuando el GamObject es destruido
}
