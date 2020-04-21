using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBall : MonoBehaviour
{
    public Transform spawnPoint;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnLost()
    {
        if (GameManager.instance.PlayerLoseLife())
        {
            rb.isKinematic = true;

            rb.velocity = new Vector2(0, 0);

            transform.SetParent(spawnPoint);

            transform.position = spawnPoint.position;
        }
        else Destroy(gameObject);
    }

    public void FinalDeJuego()
    {
        Destroy(gameObject);
    }
}
