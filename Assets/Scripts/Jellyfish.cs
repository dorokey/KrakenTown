using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    [SerializeField] public float _swimmingSpeed = 3f;
    void Update()
    {
        transform.Translate(Vector3.left * _swimmingSpeed * Time.deltaTime);
        if (transform.position.x < -9.2f)
        {
            transform.position = new Vector3(9.2f, Random.Range(5f,15), 0);
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
        }
    }
}
