using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movimiento;
    public float velocityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        movimiento = new Vector2(move, 0);

        movimiento.Normalize();

        movimiento *= velocityScale;
    }

    private void FixedUpdate()
    {
        rb.velocity = movimiento;
    }
}
