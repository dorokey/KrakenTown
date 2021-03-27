using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _lives = 3;
    [SerializeField] private float _canInk = -1f;
    [SerializeField] private float _inkRate = 0.3f;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private GameObject _inkShotPrefab;
    [SerializeField] private int _level = 1;
    [SerializeField] public bool _keyFound = false;
    void Start()
    {
        _level = 1;
        _keyFound = false;
        transform.position = new Vector3(0f,-2.9f,0f);
    }

    void Update()
    {
        //BoundaryCheck();
        PlayerMovement();
        Inking();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0f) * _speed * Time.deltaTime);
        if (transform.position.y > 81f)
            transform.position = new Vector3(transform.position.x, y: 80.19f, z: 0f);
        else if (transform.position.y < -8.2f)
            transform.position = new Vector3(transform.position.x, y: -8.19f, z: 0f);
        else if (transform.position.x > 9.2f)
            transform.position = new Vector3(x: -9.19f, transform.position.y, z: 0f);
        else if (transform.position.x < -9.2f)
            transform.position = new Vector3(x: 9.19f, transform.position.y, z: 0f);
    }

    /*
    void BoundaryCheck()
    {
        if (_keyFound)
        {
            if (transform.position.y >= 13.8f && (transform.position.x <= -0.1f || transform.position.x >= 3.65f))
                transform.position = new Vector3(x: transform.position.x, transform.position.y, z: 0f);
            if (transform.position.y >= 14f)
            {
                keysRestart();
                _level = 2;
            }
        }
        else
        {
            if (_level == 1)
            {
                Debug.Log("I have started");
                if (transform.position.y >= 13.8f && (transform.position.x <= -0.1f || transform.position.x >= 3.65f))
                    transform.position = new Vector3(x: transform.position.x, 13.79f, z: 0f);
            }
            else if (_level == 2)
            {
                if (transform.position.y >= 13.8f)
                    transform.position = new Vector3(x: transform.position.x, 13.79f, z: 0f);
            }
            else if (_level == 3)
            {
                if (transform.position.y >= 13.8f)
                    transform.position = new Vector3(x: transform.position.x, 13.79f, z: 0f);
            }
        }
    }
    */
    
    public void Damage()
    {
        _lives -= 1f;
        if (_lives <= 0f)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            Destroy(_spawnManager.gameObject);
        }
    }
    public void DamageShreds()
    {
        _lives -= 0.25f;
        if (_lives == 0f)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            Destroy(_spawnManager.gameObject);
        }
    }
    void Inking()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canInk)
        {
            _canInk = Time.time + _inkRate;
            Instantiate(_inkShotPrefab, transform.position + new Vector3(x: 0f, 0.74f, 0f), Quaternion.identity);
        }
    }

    public void keysFound()
    {
        _keyFound = true;
    }

    public void keysRestart()
    {
        _keyFound = false;
    }
}
