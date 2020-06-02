using UnityEngine;

/*
 * Script para darle movimiento a las animaciones del menú
 */

public class MovimientoAnimacion : MonoBehaviour
{
    public float speed, alejamiento;
    Vector2 posicion;

    void Start()
    {
        posicion = transform.position;  // Guardamos la posicion del gameObject
        speed = speed / 10;             // Para que vaya mas lento
    }

    
    void Update()
    {
        if (transform.position.x >= posicion.x + alejamiento) // Cambiamos de velocidad cuando pas los limites
            speed = -speed;
        if (transform.position.x <= posicion.x - alejamiento)
            speed = -speed;
        transform.Translate(speed, 0, 0);     // Al no tener RigidBody movemos los gameObject por Translate
    }
}
