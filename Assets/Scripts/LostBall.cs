using UnityEngine;

public class LostBall : MonoBehaviour
{
    public Transform spawnPoint;    // Variable publica donde desde el editor ponemos el spawn de la bola
    private Rigidbody2D rb;         // Variable para guardar el componente RigidBody del GameObject

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Le damos el valor del RigidBody del GameObject
    }

    public void OnLost()
    {
        if (GameManager.instance.PlayerLoseLife()) // Si el GameManager le dice que tiene vidas (== true)
        {
            rb.isKinematic = true;                      // Hacemos que la Bola sea cinematica

            rb.velocity = Vector2.zero;                 // Le quitamos la velocidad que tenia

            transform.SetParent(spawnPoint.parent);     // Ponemos de padre la pala, la cual tiene de hijo al spawnPoint

            transform.position = spawnPoint.position;   // Y la colocamos en la posicion del spawnPoint
        }
        else Destroy(gameObject);                  // En el caso contario destruimos la Bola
    }
}
