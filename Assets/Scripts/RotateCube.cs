using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;   // for the GUI

public class RotateCube : MonoBehaviour {

    [SerializeField] GameObject objectWithSerialConnect;        // the object to which the SerialConnect script is attached

    // what to send to the Arduino when you press the action Button
    private SerialConnect myScript;
 
    // to receive values from the Arduino
    private List<int> actValues;

    private Quaternion origRot;

    // Use this for initialization
    void Start () {
        myScript = objectWithSerialConnect.GetComponent<SerialConnect>();
        origRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        // get values from Arduino
        actValues = myScript.values;
         
        if (actValues.Count >= 4)
        { // (In this case) if a valid measurement
            Quaternion newRot = new Quaternion(actValues[0], -actValues[2], actValues[1], actValues[3]);    // Gidi: since MPU9150 is righthanded and Unity left-handed
            this.transform.rotation = newRot * origRot; 
        }

    }
}
