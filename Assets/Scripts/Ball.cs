using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private float speedy, speedx;
    Vector2 velocidad;
    private bool jugando;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        velocidad = new Vector2(0, 0);
        speedy = speedx = speed;
        jugando = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && jugando)
        {
            rb.isKinematic = false;

            transform.SetParent(null);

            velocidad = new Vector2(0, speedy);

            jugando = false;
        }
    }
    private void FixedUpdate()
    {
        if (!jugando) rb.AddForce(velocidad);
    }
}
