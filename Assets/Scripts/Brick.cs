using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.AddBrick();
    }
    private void Update()
    {
        if(this.gameObject == null)
        {
            Debug.Log("Esta muertito");
            GameManager.instance.BrickDestroyed();
        }
    }
}
