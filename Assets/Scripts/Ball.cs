using UnityEngine;

public class Ball : MonoBehaviour
{
    // Variable que se puede editar en el editor de Unity.
    public float speed;

    // Variable para guardar el componente RigidBody del GameObject.
    private Rigidbody2D rb;

    // Vector para almacenar la velocidad de la Bola.
    private Vector2 velocidad;         

    private void Start()
    {
        // Le damos el valor del RigidBody del GameObject.
        rb = GetComponent<Rigidbody2D>();  
    }

    private void Update()
    {
        // Si le damos a la tecla Enter y el objeto es cinemático,
        if (Input.GetKeyDown(KeyCode.Return) && rb.isKinematic == true) 
        {
            // lo convertimos en un objeto físico
            rb.isKinematic = false;

            // y deja de ser padre de la pala.
            transform.SetParent(null);

            // Creamos un vector donde da dos valores 
            // aleatorios en los argumentos, x e y.
            velocidad = new Vector2(Random.Range(-10, 10), Random.Range(1, 10));

            // Normalizamos para que la velocidad sea la que queremos en el editor.
            velocidad.Normalize();

            // Multiplicamos el vector por la velocidad que se quiera.
            velocidad *= speed;

            // La bola se mueve, colocando el vector anterior en el vector de su velocidad.
            rb.velocity = velocidad;      
        }
        if(GameManager.instance != null)
        {
            // En el caso de que no estemos jugando,
            if (!GameManager.instance.GetJugando())
            {
                // paramos la pelota para no poder perder vidas.
                rb.velocity = Vector2.zero;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        // Creamos la variable para no coger dos veces el componente.
        PlayerController pala = other.gameObject.GetComponent<PlayerController>();

        // Si el GameObject con el que colisiona tiene el componente PlayerController.
        if (pala)    
        {
            // Almacenamos el valor de donde choca sobre la pala.
            float hitFactor = pala.HitFactor(gameObject.transform.position);

            // Cramos un nuevo vector con el valor de donde ha chocado.
            velocidad = new Vector2(hitFactor, 1);

            // Normalizamos para que no cambie la velocidad.
            velocidad.Normalize();

            // Multiplicamos el vector por la velocidad que se quiera.
            velocidad *= speed;

            // La bola se mueve, colocando el vector anterior en el vector de su velocidad.
            rb.velocity = velocidad;                
                                                    
        }
    }
} 
