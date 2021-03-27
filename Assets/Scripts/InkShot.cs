using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkShot : MonoBehaviour
{
    [SerializeField] private float _inkSpeed = 6f;

    void Update()
    {
        transform.Translate(Vector3.up * _inkSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * 100f * Time.deltaTime);
        if (transform.position.y > 15f)
        {
            Destroy(this.gameObject);
        }
    }
}
