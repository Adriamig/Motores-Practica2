using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    public Sprite naveGrande;
    private Sprite miNave;

    void OnEnable()
    {
        miNave = gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = naveGrande;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.AddComponent<BoxCollider2D>();
    }

    private void OnDisable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = miNave;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.AddComponent<BoxCollider2D>();
    }
   
}
