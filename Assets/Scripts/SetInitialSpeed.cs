using UnityEngine;

public class SetInitialSpeed : MonoBehaviour
{
    public Vector2 speed;      // Variable publica para editar la velocidad en el editor de Unity
    private Rigidbody2D rb;    // Variable para leer el componente Rigidbody del GameObject

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();           // Cogemos el componente RigidBody del gameObject
        rb.velocity = speed;                        // Le damos la velocidad que queremos desde el editor de Unity
    } // Solo se ejecuta en el Start ya que una vez modificada la velocidad
      // no hace falta un Update para cambiarla
}
