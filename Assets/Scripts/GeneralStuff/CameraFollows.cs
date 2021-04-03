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
    
    void CameraMovement()
    {
        if (targetObject != null)
        {
            if (targetObject.transform.position.y > -3.26f && targetObject.transform.position.y < 73.4)
            {
                Vector3 newPosition = new Vector3(x: 0f, y: targetObject.transform.position.y, z: -10f);
                transform.position = newPosition;
            }
        }
    }
    
}
