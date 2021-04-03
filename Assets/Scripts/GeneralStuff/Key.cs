using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private float _floatingSpeed = 4f;
    void Update()
    {
        transform.Translate(Vector3.down * _floatingSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Random.Range(-5f, 5f) * Time.deltaTime);
        if (transform.position.y < -8.2f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !(this.name.Contains("Drachmen")))
        {
            other.GetComponent<Player>().CountThemKeys();
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Player") && this.name.Contains("Drachmen"))
        {
            other.GetComponent<Player>().RelayScore(1);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Ink") || other.CompareTag("SuperInk"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
