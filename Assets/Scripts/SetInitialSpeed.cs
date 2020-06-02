using UnityEngine;

public class SetInitialSpeed : MonoBehaviour
{
    // Variable pública para editar la velocidad en el editor de Unity.
    public Vector2 speed;

    // Variable para leer el componente RigidBody del GameObject.
    private Rigidbody2D rb;

    // Solo se ejecuta en el Start ya que una vez modificada
    // la velocidad no hace falta un Update para cambiarla.
    private void Start()
    {
        // Cogemos el componente RigidBody del GameObject.
        rb = GetComponent<Rigidbody2D>();

        // Le damos la velocidad que queremos desde el editor de Unity.
        rb.velocity = speed;                        
    } 
     
}
