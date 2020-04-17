using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialSpeed : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        // Como la velocidad es muy grande he decidido dividirlo entre 10 el valor dado para no poner decimales un Unity
        speed = speed / 10f;
    }

    void Update()
    {
        this.gameObject.transform.Translate(0, speed, 0);
    }
}
