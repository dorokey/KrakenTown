using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _floatingSpeed = 6f;

    void Update()
    {
        transform.Translate(Vector3.down * _floatingSpeed * Time.deltaTime);
        transform.Rotate(Vector3.down * 30f * Time.deltaTime);
        if (transform.position.y < -8.6f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (this.CompareTag("Lives"))
            {
                other.GetComponent<Player>().ExtraLife();
            } 
            else if (this.gameObject.CompareTag("Shield"))
            {
                other.GetComponent<Player>().ActivateShield();
            }
            else if (this.gameObject.CompareTag("SuperInk"))
            {
                other.GetComponent<Player>().ActivatePowerUp();
            }
            else if (this.CompareTag("Tsunami"))
            {
                other.GetComponent<Player>().GetTsunami();
            }
            else if (this.CompareTag("Wave"))
            {
                other.GetComponent<Player>().GetShockwave();
            }
            else if (this.CompareTag("ExtraSpeed"))
            {
                other.GetComponent<Player>().ActivateExtraSpeed();
            }
            else if (this.CompareTag("Glowstick"))
            {
                other.GetComponent<Player>().ActivateGlowstick();
            }
            else if (this.CompareTag("Slow"))
            {
                other.GetComponent<Player>().ActivateSnailMode();
            }
            else if (this.CompareTag("MinusPoints"))
            {
                other.GetComponent<Player>().RelayScore(-2);
            }
            else if (this.CompareTag("LocalShield"))
            {
                other.GetComponent<Player>().GetLocalShield();
            }
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Ink"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Barrier"))
            Destroy(this.gameObject);
    }
}
