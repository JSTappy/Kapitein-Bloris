using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MoveArduino : MonoBehaviour
{
    SerialPort portNo=new SerialPort("COM3",9600);
    // Start is called before the first frame update
    void Start()
    {
        portNo.Open();
        portNo.ReadTimeout = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        if(portNo.IsOpen)
        {
            try
            {
                blink_light(portNo.ReadByte());
            }
            catch(System.Exception)
            {
                UnityEngine.Debug.Log("Exception");
            }
        }
    }
    void blink_light(int stat)
    {
        if(stat == 1)
        {
            transform.Translate(Vector3.up * 1 * Time.deltaTime);
        }
        else if(stat == 2)
        {
            transform.Translate(Vector3.down * 1 * Time.deltaTime);
        }
    }
}
