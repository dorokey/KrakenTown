using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GlassShreds : MonoBehaviour
{
    [SerializeField] private float _explosion = 0.5f;
    void Update()
    {
        transform.Translate(Vector3.down * _explosion * Time.deltaTime);
        transform.Translate(Vector3.right * Random.Range(-1f, 1f) * Time.deltaTime);
        if (transform.position.y < -8.2f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().DamageShreds();
            Destroy(this.gameObject);
        } 
        else if (other.CompareTag("Ink"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
