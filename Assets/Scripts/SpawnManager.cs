using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private float _delay = 2f;
    [SerializeField] private float _jellyfishBirth = 15f;
    [SerializeField] private List<GameObject> _bottlePrefabs;
    [SerializeField] private GameObject _jellyfishPrefab;
    private bool _spawningOn = true;
    void Start()
    {
        StartCoroutine(SpawnSystem());
        StartCoroutine(JellyfishSpawn());

    }
    
    public void OnPlayerDeath()
    {
        _spawningOn = false;
    }

    IEnumerator SpawnSystem()
    {
        while (_spawningOn)
        {
            Instantiate(_bottlePrefabs[Random.Range(0,_bottlePrefabs.Count)],new Vector3(Random.Range(-9f,9f), 15.4f, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }
    }
    /*
    IEnumerator SpawnPowerUp()
    {
        while (_spawningOn)
        {
            Instantiate(_powerUps[Random.Range(0,_powerUps.Count)], new Vector3(Random.Range(-9f,9f), 7f, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_UVlightPowerupsRate);
        }
    }
    */
    
    IEnumerator JellyfishSpawn()
    {
        while (_spawningOn)
        {
            Instantiate(_jellyfishPrefab,new Vector3(9.2f, Random.Range(-5f,15f), 0f), Quaternion.identity, this.transform);
            _jellyfishBirth = Random.Range(15f, 30f);
            yield return new WaitForSeconds(_jellyfishBirth);
        }
    }
}
