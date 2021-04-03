using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _jellyfishBirth = 3f;
    [SerializeField] private List<GameObject> _bottlePrefabs;
    [SerializeField] private List<GameObject> _powerUpPrefabs;
    [SerializeField] private List<GameObject> _oldBootPrefabs;
    [SerializeField] private GameObject _jellyfishPrefabRight;
    [SerializeField] private GameObject _jellyfishPrefabLeft;
    [SerializeField] private GameObject _keyPrefab;
    [SerializeField] private GameObject _drachmenPrefab;
    [SerializeField] private float _keyDelay = 20f;
    [SerializeField] private float _bootsDelay = 1f;
    [SerializeField] private float _powUpDelay = 10f;
    [SerializeField] private float _drachmenDelay = 6f;
    public int _levelUp = 1;
    private bool _spawningOn = true;
    private bool _levelOne = true;
    private bool _levelTwo = true;
    void Start()
    {
        //level 1
        StartCoroutine(SpawnBottles());
        StartCoroutine(JellyfishSpawn());
        StartCoroutine(KeySpawnL1());
        StartCoroutine(PowerUpsGo(13.8f));
        StartCoroutine(DrachmenSpawnL1());

        //stiefel level 2
        //StartCoroutine(JellyfishSpawn2());
        //StartCoroutine(KeySpawnL2());
        //StartCoroutine(DrachmenSpawnL2());
        StartCoroutine(PowerUpsGo(42.3f));
        //StartCoroutine(OldBoots());
        
        //level 3
        //StartCoroutine(KeySpawnL3());
        //StartCoroutine(JellyfishSpawn3());
        //StartCoroutine(JellyfishSpawn4());
        //StartCoroutine(DrachmenSpawnL3());
        StartCoroutine(PowerUpsGo(80.1f));

    }
    

    //turn off spawning when done
    public void OnPlayerDeath()
    {
        _spawningOn = false;
    }

    public void LevelOne()
    {
        _levelOne = false;
    }
    public void LevelTwo()
    {
        _levelTwo = false;
    }

    public void UpYourLevel()
    {
        _levelUp += 1;
    }

    IEnumerator SpawnBottles()
    {
        while (_spawningOn && _levelOne)
        {
            Instantiate(_bottlePrefabs[Random.Range(0,_bottlePrefabs.Count)],new Vector3(Random.Range(-9f,9f), 15.4f, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }
    }
    IEnumerator JellyfishSpawn()
    {
        while (_spawningOn)
        {
            Instantiate(_jellyfishPrefabLeft,new Vector3(-9.2f, Random.Range(-5f,15f), 0f), Quaternion.identity, this.transform);
            _jellyfishBirth = Random.Range(3f, 13f);
            yield return new WaitForSeconds(_jellyfishBirth);
        }
    }
    IEnumerator JellyfishSpawn2()
    {
        while (_spawningOn)
        {
            Instantiate(_jellyfishPrefabRight,new Vector3(9.2f, Random.Range(18f,43f), 0f), Quaternion.Euler(0f,-180f,0f), this.transform);
            _jellyfishBirth = Random.Range(3f, 13f);
            yield return new WaitForSeconds(_jellyfishBirth);
        }
    }
    IEnumerator JellyfishSpawn3()
    {
        while (_spawningOn)
        {
            Instantiate(_jellyfishPrefabLeft,new Vector3(-9.2f, Random.Range(46f,76f), 0f), Quaternion.identity, this.transform);
            _jellyfishBirth = Random.Range(1f, 5f);
            yield return new WaitForSeconds(_jellyfishBirth);
        }
    }
    IEnumerator JellyfishSpawn4()
    {
        while (_spawningOn)
        {
            Instantiate(_jellyfishPrefabRight,new Vector3(9.2f, Random.Range(46f,76f), 0f), Quaternion.Euler(0f,-180f,0f), this.transform);
            _jellyfishBirth = Random.Range(1f, 5f);
            yield return new WaitForSeconds(_jellyfishBirth);
        }
    }
    
    
    //stiefel level 2
    IEnumerator OldBoots()
    {
        while (_spawningOn && _levelTwo)
        {
            Instantiate(_oldBootPrefabs[Random.Range(0,_oldBootPrefabs.Count)],new Vector3(Random.Range(-9f,9f), 45f, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_bootsDelay);
        }
    }
    
    //Keys spawning
    IEnumerator KeySpawnL1()
    {
        while (_spawningOn && _levelOne)
        {
            Instantiate(_keyPrefab,new Vector3(Random.Range(-9f,9f), 15.4f,0f), Quaternion.identity, this.transform);
            _keyDelay = Random.Range(5f, 25f);
            yield return new WaitForSeconds(_keyDelay);
        }
    }
    IEnumerator KeySpawnL2()
    {
        while (_spawningOn && _levelTwo)
        {
            Instantiate(_keyPrefab,new Vector3(Random.Range(-9f,9f), 43f,0f), Quaternion.identity, this.transform);
            _keyDelay = Random.Range(5f, 25f);
            yield return new WaitForSeconds(_keyDelay);
        }
    } 
    IEnumerator KeySpawnL3()
    {
        while (_spawningOn)
        {
            Instantiate(_keyPrefab,new Vector3(Random.Range(-9f,9f), 80f,0f), Quaternion.identity, this.transform);
            _keyDelay = Random.Range(5f, 25f);
            yield return new WaitForSeconds(_keyDelay);
        }
    }
    
    //powerupSpawns: lives, shield, superInk
    IEnumerator PowerUpsGo(float border)
    {
        while (_spawningOn)
        {
            Instantiate(_powerUpPrefabs[Random.Range(0,_powerUpPrefabs.Count)],new Vector3(Random.Range(-9f,9f), border, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_powUpDelay);
        }
    }
    
    //drachmen spawning
    IEnumerator DrachmenSpawnL1()
    {
        while (_spawningOn && _levelOne)
        {
            float _xkoo = Random.Range(-9f, 9f);
            for(int i = 0; i < 3; i++)
            {
                Instantiate(_drachmenPrefab,new Vector3(_xkoo + 0.2f,15.4f,0f), Quaternion.identity, this.transform);
            }
            _drachmenDelay = Random.Range(3f, 15f);
            yield return new WaitForSeconds(_drachmenDelay);
        }
    }
    IEnumerator DrachmenSpawnL2()
    {
        while (_spawningOn && _levelTwo)
        {
            float _xkoo = Random.Range(-9f, 9f);
            for(int i = 0; i < 3; i++)
            {
                Instantiate(_drachmenPrefab,new Vector3(_xkoo + 0.2f, 43f,0f), Quaternion.identity, this.transform);
            }
            _drachmenDelay = Random.Range(3f, 13f);
            yield return new WaitForSeconds(_drachmenDelay);
        }
    } 
    IEnumerator DrachmenSpawnL3()
    {
        while (_spawningOn)
        {
            float _xkoo = Random.Range(-9f, 9f);
            for(int i = 0; i < 3; i++)
            {
                Instantiate(_drachmenPrefab,new Vector3(_xkoo + 0.2f, 80 + i * 0.1f,0f), Quaternion.identity, this.transform);
            }
            _drachmenDelay = Random.Range(3f, 13f);
            yield return new WaitForSeconds(_drachmenDelay);
        }
    }
    
    
    
    
}
