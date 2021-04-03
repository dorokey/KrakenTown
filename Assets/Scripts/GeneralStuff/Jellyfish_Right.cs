using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish_Right : MonoBehaviour
{
    
    [SerializeField] public float _swimmingSpeed = 3f;
    void Update()
    {
        transform.Translate(Vector3.right * _swimmingSpeed * Time.deltaTime);
        if (transform.position.x < -9.2f)
        {
            Destroy(this.gameObject);
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

}
