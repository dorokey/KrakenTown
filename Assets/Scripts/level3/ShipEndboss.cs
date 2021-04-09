using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipEndboss : MonoBehaviour
{
    public Transform targetObject;
    [SerializeField] private float _movementSpeed = 1.5f;
    [SerializeField] private bool _directionLeft = true;
    [SerializeField] private GameObject _motoroilPrefab;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private float _xkoo = 0f;
    [SerializeField] public float _stillAlive = 5f;
    [SerializeField] private float _delay = 0.6f;
    public bool _defeat = false;


    void Start()
    {
        StartCoroutine(Shooteroo());
        _directionLeft = true;
        _defeat = false;
    }

    private void Update()
    {
        if (_directionLeft)
        {
            transform.Translate(Vector3.down * _movementSpeed * Time.deltaTime);
            if (transform.position.x <= -5.9f)
            {
                _directionLeft = false;
            }
        }
        if (_directionLeft == false)
        {
            transform.Translate(Vector3.up * _movementSpeed * Time.deltaTime);
            if (transform.position.x >= 5.9f)
            {
                _directionLeft = true;
            }
        }
    }

    IEnumerator Shooteroo()
    {
        while ( (_stillAlive > 0) && (targetObject != null) )
        {
            Instantiate(_motoroilPrefab, transform.position + new Vector3(x: _xkoo , -2.5f, 0f), Quaternion.identity);
            _xkoo = Random.Range(-1.5f, 1.5f);
            yield return new WaitForSeconds(_delay);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage();
        }
        else if (other.CompareTag("Ink"))
        {
            this.EndbossDamage();
            Destroy(other.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(4);
        }
        else if (other.CompareTag("SuperInk"))
        { 
            this.EndbossDamage();
            this.EndbossDamage();
            Destroy(other.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(4);
        }
        else if (other.CompareTag("Shield"))
        {
            Destroy(other.gameObject);
        }
    }

    private void EndbossDamage()
    {
        _stillAlive -= 0.2f;
        if (_stillAlive <= 0f)
        {
            _defeat = true;
        }
        _uiManager.EndbossDemise(0.2f);
    }

    public bool EndbossAlive()
    {
        return _defeat;
    }
}
