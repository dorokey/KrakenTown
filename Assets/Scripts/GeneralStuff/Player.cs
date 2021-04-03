using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _lives = 3;
    [SerializeField] private float _canInk = -1f;
    [SerializeField] private float _inkRate = 0.3f;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private GameObject _inkShotPrefab;
    [SerializeField] private GameObject _superInkPrefab;
    [SerializeField] private GameObject _shieldPrefab;
    [SerializeField] private GameObject _endbossPrefab;
    [SerializeField] private GameObject _tsunamiPrefab;
    [SerializeField] private GameObject _shockWavePrefab;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private int _level = 1;
    [SerializeField] public bool _keyFound = false;
    [SerializeField] public int _keyNumber = 0;
    [SerializeField] private bool _superInk = false;
    [SerializeField] private float _powerupTimeout = 5f;
    

    void Start()
    {
        _level = 1;
        _keyFound = false;
        _keyNumber = 0;
        transform.position = new Vector3(0f, -2.9f, 0f);
    }

    void Update()
    {
        PlayerMovement();
        Inking();
        CheckAllKeys();
        CheckVictory();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0f) * _speed * Time.deltaTime);
        if (_level == 1)
        {
            if (_keyFound)
            {
                if (transform.position.y > 13.8f && (transform.position.x > 0.7f && transform.position.x < 2.3f))
                {
                    transform.position = new Vector3(x: transform.position.x, transform.position.y, z: 0f);
                    if (transform.position.y > 14f)
                    {
                        _level = 2;
                        _spawnManager.UpYourLevel();
                        _spawnManager.LevelOne();
                        GameObject.FindWithTag("Spawnmanager").GetComponent<SpawnManager>()
                            .StartCoroutine("DrachmenSpawnL2");
                        GameObject.FindWithTag("Spawnmanager").GetComponent<SpawnManager>()
                            .StartCoroutine("JellyfishSpawn2");
                        GameObject.FindWithTag("Spawnmanager").GetComponent<SpawnManager>()
                            .StartCoroutine("KeySpawnL2");
                        GameObject.FindWithTag("Spawnmanager").GetComponent<SpawnManager>()
                            .StartCoroutine("OldBoots");
                        keysRestart();
                    }
                }
                else if (transform.position.y > 13.8f && !(transform.position.x > 0.7f && transform.position.x < 2.3f) )
                {
                    transform.position = new Vector3(x: transform.position.x, 13.79f, 0f);
                }
                else
                {
                    if (transform.position.y >= 13.8f)
                        transform.position = new Vector3(transform.position.x, y: 13.79f, z: 0f);
                    else if (transform.position.y < -8.2f)
                        transform.position = new Vector3(transform.position.x, y: -8.19f, z: 0f);
                    else if (transform.position.x > 9.2f)
                        transform.position = new Vector3(x: -9.19f, transform.position.y, z: 0f);
                    else if (transform.position.x < -9.2f)
                        transform.position = new Vector3(x: 9.19f, transform.position.y, z: 0f);
                }
            }
            else
            {
                if( transform.position.y > 13.8f && transform.position.x > 0.7f && transform.position.x < 2.3f)
                    _uiManager.KeysMissing();
                
                if (transform.position.y >= 13.8f)
                    transform.position = new Vector3(transform.position.x, y: 13.79f, z: 0f);
                else if (transform.position.y < -8.2f)
                    transform.position = new Vector3(transform.position.x, y: -8.19f, z: 0f);
                else if (transform.position.x > 9.2f)
                    transform.position = new Vector3(x: -9.19f, transform.position.y, z: 0f);
                else if (transform.position.x < -9.2f)
                    transform.position = new Vector3(x: 9.19f, transform.position.y, z: 0f);
            }
        }
        else if (_level == 2)
        {
            if (_keyFound)
            {
                if (transform.position.y > 43.2f && (transform.position.x > -6.2f && transform.position.x < -3.6f))
                {
                    transform.position = new Vector3(x: transform.position.x, transform.position.y, z: 0f);
                    if (transform.position.y > 43.3f)
                    {
                        _level = 3;
                        _spawnManager.UpYourLevel();
                        _spawnManager.LevelTwo();
                        GameObject.FindWithTag("Spawnmanager").GetComponent<SpawnManager>()
                            .StartCoroutine("DrachmenSpawnL3");
                        GameObject.FindWithTag("Spawnmanager").GetComponent<SpawnManager>()
                            .StartCoroutine("JellyfishSpawn4");
                        GameObject.FindWithTag("Spawnmanager").GetComponent<SpawnManager>()
                            .StartCoroutine("JellyfishSpawn3");
                        GameObject.FindWithTag("Spawnmanager").GetComponent<SpawnManager>()
                            .StartCoroutine("KeySpawnL3");
                        keysRestart();
                    }
                }
                else if (transform.position.y > 43.2f && !(transform.position.x > 6.2f && transform.position.x < -3.6f))
                {
                    transform.position = new Vector3(x: transform.position.x, 43.19f, 0f);
                }
                else
                {
                    if (transform.position.y >= 43.2f)
                        transform.position = new Vector3(transform.position.x, y: 43.19f, z: 0f);
                    else if (transform.position.y < 16.4f)
                        transform.position = new Vector3(transform.position.x, y: 16.41f, z: 0f);
                    else if (transform.position.x > 9.2f)
                        transform.position = new Vector3(x: -9.19f, transform.position.y, z: 0f);
                    else if (transform.position.x < -9.2f)
                        transform.position = new Vector3(x: 9.19f, transform.position.y, z: 0f);
                }
            }
            else
            {
                if (transform.position.y > 43.2f && transform.position.x > -6.2f && transform.position.x < -3.6f)
                    _uiManager.KeysMissing();
                
                if (transform.position.y >= 43.2f)
                    transform.position = new Vector3(transform.position.x, y: 43.19f, z: 0f);
                else if (transform.position.y < 16.4f)
                    transform.position = new Vector3(transform.position.x, y: 16.41f, z: 0f);
                else if (transform.position.x > 9.2f)
                    transform.position = new Vector3(x: -9.19f, transform.position.y, z: 0f);
                else if (transform.position.x < -9.2f)
                    transform.position = new Vector3(x: 9.19f, transform.position.y, z: 0f);
            }
        }
        else if (_level == 3)
        {
            if (transform.position.y >= 76.8f)
                transform.position = new Vector3(transform.position.x, y: 76.79f, z: 0f);
            else if (transform.position.y < 46f)
                transform.position = new Vector3(transform.position.x, y: 46.1f, z: 0f);
            else if (transform.position.x > 9.2f)
                transform.position = new Vector3(x: -9.19f, transform.position.y, z: 0f);
            else if (transform.position.x < -9.2f)
                transform.position = new Vector3(x: 9.19f, transform.position.y, z: 0f);
        }
    }

    public void Damage()
    {
        _lives -= 1f;
        _uiManager.ChangeLives(-1f);
        if ( _lives <= 0f )
        {
            _uiManager.YouLost();
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            Destroy(_spawnManager.gameObject);
            Destroy(_endbossPrefab.gameObject);
        }
    }

    private void CheckVictory()
    {
        if (GameObject.FindWithTag("Endboss").GetComponent<ShipEndboss>().EndbossAlive())
        {
            _uiManager.YouWon();
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            Destroy(_spawnManager.gameObject);
            Destroy(_endbossPrefab.gameObject);
        }
    }

    public void ExtraLife()
    {
        _lives += 1;
        _uiManager.ChangeLives(1f);
    }

    public void DamageShreds()
    {
        _lives -= 0.25f;
        _uiManager.ChangeLives(-0.25f);
        if ( _lives <= 0f )
        {
            _uiManager.YouLost();
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            Destroy(_uiManager.gameObject);
            Destroy(_spawnManager.gameObject);
            Destroy(_endbossPrefab.gameObject);
        }
    }

    void Inking()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canInk)
        {
            _canInk = Time.time + _inkRate;
            if (_superInk)
            {
                Instantiate(_superInkPrefab, transform.position + new Vector3(x: 0f, 0.74f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(_inkShotPrefab, transform.position + new Vector3(x: 0f, 0.74f, 0f), Quaternion.identity);
            }
        }
    }

    public void keysRestart()
    {
        _keyFound = false;
        _keyNumber = 0;
        _uiManager.KeysReset();
    }

    public void CountThemKeys()
    {
        _keyNumber += 1;
        _uiManager.KeysCollected(1);
    }

    private void CheckAllKeys()
    {
        if (_keyNumber >= 3)
            _keyFound = true;
    }

    public void ActivatePowerUp()
    {
        _superInk = true;
        StartCoroutine(DeactivatePowerup());
    }

    IEnumerator DeactivatePowerup()
    {
        yield return new WaitForSeconds(_powerupTimeout);
        _superInk = false;
    }

    public void ActivateShield()
    {
        Transform charTransform = GetComponent<Player>().transform;
        GameObject newShield = Instantiate(_shieldPrefab, charTransform.position, charTransform.rotation);
        newShield.transform.SetParent(charTransform);
    }
    public void GetTsunami()
    {
        Instantiate(_tsunamiPrefab, transform.position, Quaternion.identity);
    }
    
    public void RelayScore(int score)
    {
        _uiManager.AddScore(score);
    }

    public void GetShockwave()
    {
        if (transform.position.y > -8f && transform.position.y < 15f)
        {
            Instantiate(_shockWavePrefab, new Vector3(0f,-8f,0f), Quaternion.identity);
        }
        else if ( (transform.position.y > 15f && transform.position.y < 45f) )
        {
            Instantiate(_shockWavePrefab, new Vector3(0f,15f,0f), Quaternion.identity);
        }
        else if( (transform.position.y > 45f && transform.position.y < 76f))
        {
            Instantiate(_shockWavePrefab, new Vector3(0f,45f,0f), Quaternion.identity);
        }
    }

    public void ActivateExtraSpeed()
    {
        _speed = 12f;
        StartCoroutine(DeactivateExtraSpeed());
    }

    IEnumerator DeactivateExtraSpeed()
    {
        yield return new WaitForSeconds(5f);
        _speed = 8f;
    }
    
}