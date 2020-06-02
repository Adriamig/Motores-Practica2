using UnityEngine;

public class LostBall : MonoBehaviour
{
    // Variable pública donde desde el editor ponemos el spawn de la bola.
    public Transform spawnPoint;

    // Variable para guardar el componente RigidBody del GameObject.
    private Rigidbody2D rb;         

    private void Start()
    {
        // Le damos el valor del RigidBody del GameObject.
        rb = GetComponent<Rigidbody2D>();  
    }

    public void OnLost()
    {
        // Si el GameManager le dice que tiene vidas (== true),
        if (GameManager.instance.PlayerLoseLife()) 
        {
            // hacemos que la Bola sea cinemática,
            rb.isKinematic = true;

            // le quitamos la velocidad que tenía,
            rb.velocity = Vector2.zero;

            // ponemos de padre la pala, la cual tiene de hijo al spawnPoint,
            transform.SetParent(spawnPoint.parent);

            // y la colocamos en la posición del spawnPoint.
            transform.position = spawnPoint.position;  
        }
        // En caso contario, destruimos la Bola.
        else Destroy(gameObject);                 
    }
}
