using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkShot : MonoBehaviour
{
    [SerializeField] private float _inkSpeed = 6f;
    private Vector3 scaleChange = new Vector3(0.005f, 0.005f, 0.005f);
    void Update()
    {
        if (name.Contains("SuperInk"))
        {
            transform.localScale += scaleChange;
        }
        transform.Translate(Vector3.up * _inkSpeed * Time.deltaTime);
        if (transform.position.y > 80f) 
            Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);
        }
    }
}
