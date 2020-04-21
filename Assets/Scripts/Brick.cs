using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.AddBrick();
    }

    private void OnDisable()
    {
        GameManager.instance.BrickDestroyed();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.instance.FinalDeJuego())
        {
            other.gameObject.GetComponent<LostBall>().FinalDeJuego();
        }
    }
}
