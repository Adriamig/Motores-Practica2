using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private float speedy, speedx;
    Vector2 velocidad, parado;
    private bool jugando, fuerza;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        velocidad = parado = new Vector2(0, 0);
        speedy = speedx = speed*50;
        jugando = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !jugando)
        {
            rb.isKinematic = false;

            transform.SetParent(null);

            velocidad = new Vector2(speedx, speedy);

            jugando = true;
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity == parado && jugando) 
        {
            rb.AddForce(velocidad);
            jugando = false;
        }
    }
}
