using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public Transform target;
    private float smoothSpeed = 0.1f;
    public Vector3 offset;

    void Start(){
        transform.rotation = new Vector3  (0.0f, 90.0f, 0.0f);
    }
    

    void FixedUpdate()
    {
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        Move();
    }

    void Move()
    {
        transform.position -= new Vector3(smoothSpeed, 0f, 0f);
    }
}
