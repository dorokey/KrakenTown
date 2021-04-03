using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _livesText;
    [SerializeField] private TextMeshProUGUI _shipLivesText;
    [SerializeField] private TextMeshProUGUI _missingKeys;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _lostText;
    [SerializeField] private TextMeshProUGUI _numberOfKeys;
    
    public int _score = 0;
    private float _lives = 3f;
    private float _shipAlive = 10f;
    public int _keysFound = 0;

    private void Start()
    {
        _livesText.text = "Lives: " + _lives;
        _scoreText.text = "Score: " + _score;
        _numberOfKeys.text = "Keys: " + _keysFound;
        _winText.gameObject.SetActive(false);
        _lostText.gameObject.SetActive(false);
        _missingKeys.gameObject.SetActive(false);
        _shipLivesText.text = "Ship Lives: " + _shipAlive;
    }

    public void AddScore(int newScore)
    {
        _score += newScore;
        _scoreText.text = "Score: " + _score;
    }

    public void ChangeLives(float lives)
    {
        _lives += lives;
        _livesText.text = "Lives: " + _lives;
    }
    
    public void EndbossDemise(float hit)
    {
        _shipAlive -= hit;
        _shipLivesText.text = "Ship Lives: " + _shipAlive;
    }
    
    public void YouWon()
    {
        _winText.gameObject.SetActive(true);
    }

    public void YouLost()
    {
        _lostText.gameObject.SetActive(true);
    }

    public void KeysCollected(int amount)
    {
        _keysFound += amount;
        _numberOfKeys.text = "Keys: " + _keysFound;
    }
    public void KeysReset()
    {
        _keysFound = 0;
        _numberOfKeys.text = "Keys: " + _keysFound;
    }

    public void KeysMissing()
    {
        _missingKeys.gameObject.SetActive(true);
        StartCoroutine(DeactivateMissingKeys());
    }

    IEnumerator DeactivateMissingKeys()
    {
        yield return new WaitForSeconds(2f);
        _missingKeys.gameObject.SetActive(false);
    }


}
