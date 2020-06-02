using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int golpesAntesDeMorir, puntosGanados;  // Variables publicas para cambiar en el editor de Unity
    public GameObject dieObject;                   // GameObject publico para instanciar posteriormente
    private int golpesPegados = 0;                 // Variable para saber cuantos golpes lleva el GameObject

    private void OnCollisionEnter2D(Collision2D other)
    {
        golpesPegados++;       // Se incrementa el valor de la variable que cuenta los golpes
        if (golpesPegados == golpesAntesDeMorir) // En el caso de que los golpes pegados sean los mismos
                                                 // que los necesarios para destruir
        {
            Destroy(this.gameObject);       // Destruyes este GameObject
            GameManager.instance.AddPuntos(puntosGanados);  // Avisa al GameManager para que añada los puntos indicados
            if(dieObject != null)           // En el caso de que hayamos puesto un GameObject en Unity,
                                            // es decir, que no sea nulo
            {
                GameObject powerUp = Instantiate(dieObject);    // Instanciamos el GameObject
                powerUp.transform.position = this.gameObject.transform.position; // Se instancia en la posicion del padre
            }
        }
    }
}
