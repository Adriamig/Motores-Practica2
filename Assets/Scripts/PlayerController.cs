using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Velocidad que se puede editar en el editor de Unity.
    public float velocityScale;

    // Variable para leer el RigidBody del GameObject.
    private Rigidbody2D rb;

    // Vector que posteriormente se guardará el movivmiento de la pala.
    private Vector2 movimiento;

    // Variable que posteriormente servirá para almacenar el ancho de la pala.
    private float width;         

    void Start()
    {
        // Le damos el valor del RigidBody del GameObject.
        rb = GetComponent<Rigidbody2D>();  
    }
    
    void Update()
    {
        // Cogemos el valor de las teclas de movimiento horizontal
        // (las flechas del teclado y "a" y "d").
        float move = Input.GetAxis("Horizontal");
        

        // Colocamos el valor del movimiento en el el vector.
        movimiento = new Vector2(move, 0);

        // Normalizamos el vector para que la velocidad sea constante.
        movimiento.Normalize();

        // Multiplicamos el vector por la velocidad que se quiera.
        movimiento *= velocityScale;

        // Y cogemos la anchura, ya que puede 
        // cambiar su valor lo ponemos en el Update.
        width = GetComponent<BoxCollider2D>().bounds.size.x / 2f; 
                                                                  
    }

    private void FixedUpdate()
    {
        // Si estamos jugando,
        if (GameManager.instance.GetJugando())
            // la pala se mueve, colocando el vector 
            // anterior en el vector de su velocidad.
            rb.velocity = movimiento;               
                                                
    }

    // Método que devuelve dónde ha chocado el Vector 2 sobre la pala.
    public float HitFactor(Vector2 ballPos)
    {
        // Devuelve un float indicando donde choca la bola respecto a la pala.
        return (ballPos.x - transform.position.x) / width; 
                                                           
    } 
}
