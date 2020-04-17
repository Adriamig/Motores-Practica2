using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public float golpesAntesDeMorir, puntosGanados;
    public GameObject dieObject;
    private float golpesPegados = 0;
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        golpesPegados++;
        if (golpesPegados == golpesAntesDeMorir)
        {
            Destroy(this.gameObject);
            GameManager.instance.AddPuntos(puntosGanados);
            if(dieObject != null)
            {
                GameObject powerUp = Instantiate(dieObject);
                powerUp.transform.position = this.gameObject.transform.position;
            }
        }
    }
}
