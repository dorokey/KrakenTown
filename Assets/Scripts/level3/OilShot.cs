using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class OilShot : MonoBehaviour
{
    [SerializeField] private float _oilSpeed = 10f;
    [SerializeField] private float _algaeSpeed = 13f;


    void Update()
    {
        if (!name.Contains("AlgaeShot"))
        {
            transform.Translate(Vector3.down * _oilSpeed * Time.deltaTime);
            if (transform.position.y < 45f )
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            transform.Translate(Vector3.down * _algaeSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().DamageShreds();
            other.GetComponent<Player>().DamageShreds();
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Ink") || other.CompareTag("SuperInk") || other.CompareTag("Shield"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(3);
        }
    }
}

