﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<LostBall>())
            other.gameObject.GetComponent<LostBall>().OnLost();
        else Destroy(other.gameObject);
    }
}
