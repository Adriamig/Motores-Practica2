using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    public Sprite naveGrande;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = naveGrande;
    }
}
