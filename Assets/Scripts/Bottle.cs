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
        if (transform.position.y < -8.2f)
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
            Destroy(this.gameObject);
        }
    }
}
