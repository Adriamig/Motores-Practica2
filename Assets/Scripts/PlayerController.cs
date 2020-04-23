using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movimiento;
    public float velocityScale;
    private float width;
    private bool stop = false;

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

        width = GetComponent<BoxCollider2D>().size.x / 2f;

        /*if(GameManager.instance.FinalDeJuego() && !stop)
        {
            stop = true;
        }*/
    }

    private void FixedUpdate()
    {
        if(!stop)
        rb.velocity = movimiento;
    }

    public float HitFactor(Vector2 ballPos)
    {
        return (ballPos.x - transform.position.x) / width;
    }
}
