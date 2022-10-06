using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MoveUpMoveDown : MonoBehaviour
{
    public GameObject Ballon;
    SerialPort portNo = new SerialPort("COM3",9600);
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
                string value = portNo.ReadLine();
                Debug.Log(value);
                if(value == "1")
                {
                    Ballon.transform.position = new Vector3(0, 100, 0);
                }
                else if(value == "2")
                {
                    Ballon.transform.position = new Vector3(0, 0, 0);
                }
            }
            catch(System.Exception)
            {
                Debug.Log("Error");
            }
        }
    }
}
