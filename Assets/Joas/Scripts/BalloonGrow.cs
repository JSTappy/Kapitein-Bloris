using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGrow : MonoBehaviour
{
    private void Update() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        else
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    } 
}
