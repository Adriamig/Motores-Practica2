using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject FirePref;
    public Transform spawnLaser;
    public Sprite naveFire;
    private Sprite miNave;
    void Start()
    {
        miNave = gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<SpriteRenderer>().sprite = naveFire;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(FirePref, spawnLaser);
        }
    }
    private void OnDisable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = miNave;
    }
}
