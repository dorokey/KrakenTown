using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OldBoots : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private GameObject _algaeShotPrefab;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //transform.Rotate(new Vector3(4f * Time.deltaTime, 10f * Time.deltaTime, 0f), Space.Self); 
        if ( (transform.position.y <= 38f && transform.position.y >= 37.95f) && name.Contains("OldBoots2"))
        {
            Instantiate(_algaeShotPrefab, transform.position, Quaternion.identity);
        }
        if ((transform.position.y <= 31f && transform.position.y >= 30.95f) && name.Contains("OldBoots2"))
        {
            Instantiate(_algaeShotPrefab, transform.position, Quaternion.identity);
        }
        if ( (transform.position.y <= 25f && transform.position.y >= 24.95f) && name.Contains("OldBoots2"))
        {
            Instantiate(_algaeShotPrefab, transform.position, Quaternion.identity);
        }
        if (transform.position.y < 16f)
        {
            transform.position = new Vector3(Random.Range(-9f, 9f), 45f, 0);
        }

        /*
        if (name.Contains("OldBoots2"))
            BootsShoot();
        */
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
    
    /*
    private void BootsShoot()
    {
        if (Time.time > _algaeFalls)
        {
            _algaeFalls = Time.time + _algaeRate;
            Instantiate(_algaeShotPrefab, transform.position, Quaternion.identity);
        }
    }
    */
    
}
