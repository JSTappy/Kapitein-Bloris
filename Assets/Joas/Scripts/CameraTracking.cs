using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform target;
    public float speed = 3.0f;
    public float accuracy = 1.0f;
    public float rotSpeed = 2.0f;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // Look at and dampen the rotation
        var rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);

        // Move towards the player
        if (Vector3.Distance(transform.position, target.position) > accuracy)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

}
