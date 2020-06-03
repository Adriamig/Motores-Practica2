using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // Variables públicas para cambiar en el editor de Unity.
    public int golpesAntesDeMorir, puntosGanados;

    // GameObject público para instanciar posteriormente.
    public GameObject dieObject;

    // Variable para saber cuántos golpes lleva el GameObject.
    private int golpesPegados = 0;                

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Se incrementa el valor de la variable que cuenta los golpes.
        golpesPegados++;

        // En el caso de que los golpes pegados sean los 
        // mismos que los necesarios para destruir,
        if (golpesPegados == golpesAntesDeMorir)        
        {
            // destruye este GameObject.
            Destroy(this.gameObject);

            if(GameManager.instance != null)
            {
                // En el caso de que ya hemos pasado el nivel que no se reseteen los puntos
                if(GameManager.instance.GetJugando())
                    // y avisa al GameManager para que añada los puntos indicados.
                    GameManager.instance.AddPuntos(puntosGanados);
            }

            // En el caso de que hayamos puesto un GameObject
            // en Unity, es decir, que no sea nulo,
            if (dieObject != null)          
            {
                // instanciamos el GameObject.
                GameObject powerUp = Instantiate(dieObject);

                // Se instancia en la posición del padre.
                powerUp.transform.position = this.gameObject.transform.position; 
            }
        }
    }
}
