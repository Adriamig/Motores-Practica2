using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAnimacion : MonoBehaviour
{
    public float speed, alejamiento;
    Vector2 posicion;
    void Start()
    {
        posicion = transform.position;
        speed = speed / 10;
    }

    
    void Update()
    {
        if (transform.position.x >= posicion.x + alejamiento)
            speed = -speed;
        if (transform.position.x <= posicion.x - alejamiento)
            speed = -speed;
        transform.Translate(speed, 0, 0);
    }
}
