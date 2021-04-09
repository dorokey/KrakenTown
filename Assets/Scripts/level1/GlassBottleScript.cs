using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class GlassBottleScript : MonoBehaviour
{
    [SerializeField] private float _floatingSpeed = 2f;
    [SerializeField] private GameObject _glassShredsPrefab;
    [SerializeField] private int _glassAmount = 3;
    
    void Start()
    {
        transform.position = new Vector3(Random.Range(-9f,9f), 15.4f, 0f);
    }
    void Update()
    {
        transform.Translate(Vector3.down * _floatingSpeed * Time.deltaTime);
        transform.Rotate(Vector3.down * 100f * Time.deltaTime);
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
            while (_glassAmount > 0)
            {
                Instantiate(_glassShredsPrefab, transform.position + new Vector3(x: Random.Range(-6f,6f), 0f, 0f), Quaternion.identity);
                _glassAmount -= 1;
            }
            _glassAmount = 3;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(3);
        }
        else if (other.CompareTag("SuperInk"))
        {
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(3);
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
