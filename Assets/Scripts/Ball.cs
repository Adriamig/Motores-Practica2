using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Vector2 velocidad;
    private bool jugando = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !jugando)
        {
            rb.isKinematic = false;

            transform.SetParent(null);

            velocidad = new Vector2(Random.Range(-10, 10), 1);

            velocidad.Normalize();

            velocidad *= speed;

            jugando = true;
        }
    }

    private void FixedUpdate()
    {
        if (jugando) 
        {
            rb.velocity = velocidad;
            jugando = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            float hitFactor = other.gameObject.GetComponent<PlayerController>().HitFactor(gameObject.transform.position);

            velocidad = new Vector2(hitFactor, 1);

            velocidad.Normalize();

            velocidad *= speed;

            jugando = true;
        }
    }
}
