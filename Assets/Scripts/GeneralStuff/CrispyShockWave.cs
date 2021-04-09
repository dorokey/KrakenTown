using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrispyShockWave : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier") )
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Bottle"))
        { 
            Destroy(other.gameObject);
        }
    }
}
