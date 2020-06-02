using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<LostBall>())          // En el caso de que tenga el componente LostBall
            other.gameObject.GetComponent<LostBall>().OnLost(); // Ejecuta el método OnLost de LostBall
        else Destroy(other.gameObject);   // En caso contrario destruye el GameObject que choque contra la DeathZone
    }
}
