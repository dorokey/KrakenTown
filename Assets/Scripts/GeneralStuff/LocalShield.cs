using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Bottle") || other.CompareTag("EvilShot") || other.CompareTag("Jellyfish"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
