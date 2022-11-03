using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 90f;
    public float turnDistance = 1f;
    public float turnDelay = 1f;
    public float turnDelayRandomness = 0.5f;

    private float turnTimer = 0f;
    private float turnDelayTimer = 0f;
    private bool turning = false;

    void Update()
    {
        if (turning)
        {
            turnTimer += Time.deltaTime;
            if (turnTimer >= turnDelay)
            {
                turnTimer = 0f;
                turning = false;
            }
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (Random.Range(0f, 1f) < 0.5f)
            {
                transform.Rotate(Vector3.left * turnSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.left * -turnSpeed * Time.deltaTime);
            }
            if (Random.Range(0f, 1f) < 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, turnDistance))
                {
                    turning = true;
                    turnDelayTimer = Random.Range(turnDelay - turnDelayRandomness, turnDelay + turnDelayRandomness);
                }
            }
        }
    }
}
