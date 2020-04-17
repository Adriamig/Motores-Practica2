using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public float golpesAntesDeMorir, puntosGanados;
    private float golpesPegados = 0;
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        golpesPegados++;
        if (golpesPegados == golpesAntesDeMorir)
        {
            Destroy(this.gameObject);
            GameManager.instance.AddPuntos(puntosGanados);
            GameManager.instance.BrickDestroyed();
        }
    }
}
