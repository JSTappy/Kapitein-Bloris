using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRight : MonoBehaviour
{
    public float speed = 1.0f;
    public float maxSpeed = 2.0f;
    public float acceleration = 1.0f;
    public float deceleration = 1.0f;

    void Update()
    {
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            speed -= deceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}

