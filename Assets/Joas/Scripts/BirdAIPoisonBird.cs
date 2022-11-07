using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAIPoisonBird : MonoBehaviour
{
    public float forwardspeed = 1.0f;
    public float upspeed = 1.0f;
    public float downspeed = 1.0f;
    public float maxSpeed = 2.0f;
    public float acceleration = 1.0f;
    public float rndUp = 0.0f;
    public float rndDown = 0.0f;

    void Start()
    {
        rndUp = Random.Range(0.0f, 1.0f);
        rndDown = Random.Range(0.0f, 1.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * forwardspeed * Time.deltaTime);

        if (forwardspeed < maxSpeed)
        {
            forwardspeed += acceleration * Time.deltaTime;
        }
        else
        {
            forwardspeed -= acceleration * Time.deltaTime;
        }
        if (rndUp > rndDown)
        {
            transform.Translate(Vector3.up * upspeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * downspeed * Time.deltaTime);
        }
        if (transform.position.x < 100.0f)
        {
            Destroy(gameObject);
        }
    }
}
