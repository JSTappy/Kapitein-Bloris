using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMove : MonoBehaviour
{

    public GameObject Midground;

    private void start()
    {
    
    }

    private void Update()
    {
        Midground.transform.Translate(Vector3.down * 4 * Time.deltaTime);
    }

    
}
