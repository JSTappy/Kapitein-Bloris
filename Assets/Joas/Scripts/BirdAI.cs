using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public GameObject birdPrefab;
    private float smoothSpeed = 0.1f;

    void Start(){
        birdPrefab.transform.rotation = Quaternion.Euler(0, 90, 0);
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
