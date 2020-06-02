using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // En el caso de que tenga el componente LostBall,
        if (other.gameObject.GetComponent<LostBall>())

            // ejecuta el método OnLost de LostBall
            other.gameObject.GetComponent<LostBall>().OnLost();

        // En caso contrario, destruye el GameObject que choque contra la DeathZone.
        else Destroy(other.gameObject);   
    }
}
