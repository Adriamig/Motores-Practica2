using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject FirePref;
    public Transform spawnLaser;
    public Sprite naveFire;
    private Rigidbody2D rb;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = naveFire;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject fire = Instantiate(FirePref, spawnLaser);
            rb = fire.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 10);
        }
    }
}
