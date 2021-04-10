using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GlowStick : MonoBehaviour
{
    [SerializeField] private float _speed = 0.01f;
    [SerializeField] private float _superSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        transform.Rotate(new Vector3(0f,0f,10f));
        //float _locus = transform.position.y;
        //_locus += _speed * Time.deltaTime;
        //transform.Translate(new Vector3(x:transform.position.x, y:_locus, 0f));
        if (transform.position.y >= 80f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Bottle") || other.CompareTag("EvilShot") || other.CompareTag("Jellyfish"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(1);
        }
    }

}
