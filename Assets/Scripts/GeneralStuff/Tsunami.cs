using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsunami : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0.025f, 0.025f, 0.025f);
    void Update()
    {
        transform.localScale += scaleChange;
        if (transform.localScale.x > 9f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("AlgaeShot"))
        {
            Destroy(other.gameObject);
        }
    }
}
