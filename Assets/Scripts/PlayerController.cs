using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocityScale;   // Velocidad que se puede editar en el editor de Unity

    private Rigidbody2D rb;       // Variable para leer el RigidBody del GameObject
    private Vector2 movimiento;   // Vector que posteriormente se guardara el movivmiento de la pala
    private float width;          // Variable que posteriormente servira para almacenar el ancho de la pala

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Le damos el valor del RigidBody del GameObject
    }
    
    void Update()
    {
        float move = Input.GetAxis("Horizontal");  // Cogemos el valor de las teclas de movimiento horizontal
                                                   // (las flechas del teclado y "a" y "d")
        movimiento = new Vector2(move, 0);         // Colocamos el valor del movimiento en el el vector

        movimiento.Normalize();                    // Normalizamos el vector para que la velocidad sea constante
         
        movimiento *= velocityScale;               // Multiplicamos el vector por la velocidad que se quiera

        width = GetComponent<BoxCollider2D>().bounds.size.x / 2f; // Y cogemos la anchura, ya que puede cambiar
                                                                  // su valor lo ponemos en el Update
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.GetJugando())   // Si estamos jugando
        rb.velocity = movimiento;               // La pala se mueve, colocando el vector anterior
                                                // en el vector de su velocidad
    }

    public float HitFactor(Vector2 ballPos)
    {
        return (ballPos.x - transform.position.x) / width; // Devuelve un float indicando donde choca la bola
                                                           // respecto a la pala
    } // Metodo que devuelve donde ha chocado el Vector 2 sobre la pala
}
