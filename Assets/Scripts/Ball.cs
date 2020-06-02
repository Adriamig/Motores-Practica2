using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;                // Variable que se puede editar en el editor de Unity

    private Rigidbody2D rb;            // Variable para guardar el componente RigidBody del GameObject
    private Vector2 velocidad;         // Vector para almacenar la velocidad de la Bola

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Le damos el valor del RigidBody del GameObject
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && rb.isKinematic == true) // Si le damos a la tecla enter y el objeto es cinematico
        {
            rb.isKinematic = false;        // Lo convertimos en un objeto fisico

            transform.SetParent(null);     // Deja de ser padre de la pala

            velocidad = new Vector2(Random.Range(-10, 10), Random.Range(1, 10)); // Creamos un vector donde da dos
                                                                                 // valores aleatorios en los argumentos x e y
            velocidad.Normalize();         // Normalizamos para que la velocidad sea la que queremos en el editor

            velocidad *= speed;            // Multiplicamos el vector por la velocidad que se quiera

            rb.velocity = velocidad;       // La bola se mueve, colocando el vector anterior
                                           // en el vector de su velocidad
        }

        if (!GameManager.instance.GetJugando()) // En el caso de que no estemos jugando
        {
            rb.velocity = Vector2.zero;         // Paramos la pelota para no poder perder vidas
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController pala = other.gameObject.GetComponent<PlayerController>(); // Creamos la variable para no coger
                                                                                   // dos veces el componente
        
        if (pala)    // Si el GameObject con el que colisiona tiene el componente PlayerControler
        {
            float hitFactor = pala.HitFactor(gameObject.transform.position); // Almacenamos el valor de donde choca sobre la pala

            velocidad = new Vector2(hitFactor, 1);  // Cramos un nuevo vector con el valor de donde ha chocado

            velocidad.Normalize();                  // Normalizamos para que no cambie la velocidad

            velocidad *= speed;                     // Multiplicamos el vector por la velocidad que se quiera

            rb.velocity = velocidad;                // La bola se mueve, colocando el vector anterior
                                                    // en el vector de su velocidad
        }
    }
} 
