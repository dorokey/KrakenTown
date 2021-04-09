using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] private float _floatingSpeed = 4f;
    
    void Start()
    {
        transform.position = new Vector3(Random.Range(-9f,9f), 15.4f, 0f);
    }
    void Update()
    {
        transform.Translate(Vector3.down * _floatingSpeed * Time.deltaTime);
        transform.Rotate(Vector3.down * 40f * Time.deltaTime);
        if (transform.position.y < -8.6f)
        {
            transform.position = new Vector3(Random.Range(-9f, 9f), 15.4f, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage();
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Ink"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(2);
        }
        else if (other.CompareTag("SuperInk"))
        {
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(2);
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
