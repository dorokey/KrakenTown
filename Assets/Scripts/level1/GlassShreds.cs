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
        transform.Translate(Vector3.right * Random.Range(-5f, 5f) * Time.deltaTime);
        transform.Translate(Vector3.up * Random.Range(-2f, 2f) * Time.deltaTime);
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
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(1);
        }
        else if (other.CompareTag("SuperInk"))
        {
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(1);
        }
        else if (other.CompareTag("Shield"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Tsunami"))
        {
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(1);
        }
    }
}
