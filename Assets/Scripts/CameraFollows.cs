using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 cameraOffset;
    public Vector3 newPosition;

    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    void LateUpdate()
    {
        CameraMovement();
    }

    /*
    void CameraMovement()
    {
        if (targetObject.transform.position.x > 4.45f)
        {
            transform.position = new Vector3(x: 4.449f, y: targetObject.transform.position.y , z: -10f);
        }
        else if (targetObject.transform.position.x < -4.3f)
        {
            transform.position = new Vector3(x: -4.229f, y: targetObject.transform.position.y , z: -10f);
        } 
        else if (targetObject.transform.position.y > 63.5f)
        {
            transform.position = new Vector3(x: targetObject.transform.position.x, y: 63.49f, z: -10f);
        }
        else
        {
            Vector3 newPosition = targetObject.transform.position + cameraOffset;
            transform.position = newPosition;
        }
    }
    */
    void CameraMovement()
    {
        if (targetObject.transform.position.y > -3.26f)
        {
            Vector3 newPosition = new Vector3(x: 0f, y: targetObject.transform.position.y, z: -10f);
            transform.position = newPosition;
        }
    }
    
}
