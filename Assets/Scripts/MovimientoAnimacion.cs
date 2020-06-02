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
        // Guardamos la posición del gameObject.
        posicion = transform.position;

        // Para que vaya más lento.
        speed = speed / 10;            
    }

    
    void Update()
    {
        // Cambiamos de velocidad cuando pase los limites.
        if (transform.position.x >= posicion.x + alejamiento) 
            speed = -speed;
        if (transform.position.x <= posicion.x - alejamiento)
            speed = -speed;

        // Al no tener RigidBody movemos los gameObject por Translate.
        transform.Translate(speed, 0, 0);     
    }
}
