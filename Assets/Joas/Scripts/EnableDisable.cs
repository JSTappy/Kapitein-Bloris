using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public GameObject objectToEnable;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            objectToEnable.SetActive(true);
        }
        else
        {
            objectToEnable.SetActive(false);
        }
    } 
}
