using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Health health;
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

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "TerrorBird")
        {
            Destroy(col.gameObject);
            health.TakeDamage(1);
        }
        if (col.gameObject.name == "SpeedBird")
        {
            Destroy(col.gameObject);
            health.TakeDamage(1);
        }
        if (col.gameObject.name == "SpeedBird(Clone)")
        {
            Destroy(col.gameObject);
            health.TakeDamage(1);
        }
        if (col.gameObject.name == "Bird_ROEkoe")
        {
            Destroy(col.gameObject);
            health.TakeDamage(1);
        }
    }

}