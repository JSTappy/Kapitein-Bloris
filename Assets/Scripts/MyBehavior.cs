using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;   // for the GUI

public class MyBehavior : MonoBehaviour
{

    //[SerializeField] GameObject StateName;      // this is the GUI element used to display the state name
    [SerializeField] GameObject ArduinoValues;  // this is the GUI element used to display the values received 
    [SerializeField] GameObject objectWithSerialConnect;        // the object to which the SerialConnect script is attached
    [SerializeField] GameObject ActionButton;   // the GUI button


    // what to send to the Arduino when you press the action Button
    private SerialConnect myScript;
    private string command = "";

    // example commands
    private const string SET_LED_ON = "x";
    private const string SET_LED_OFF = "y";
    private bool ledStatus = false; 

    // to receive values from the Arduino
    private List<int> actValues;    
   
	// Use this for initialization
	void Start () {

        //
        myScript = objectWithSerialConnect.GetComponent<SerialConnect>();
        command = myScript.commandToSend;
	}

    // Update is called once per frame
    void Update()
    {
        // get current state of command 
        command = myScript.commandToSend;

        // get values from Arduino
		actValues = myScript.values;
		if (actValues.Count >= 0) { // (In this case) if a valid measurement
            string resultString = "";
            for (int i = 0; i < actValues.Count; i++)
            {
                if (resultString != "")
                {
                    resultString += ",";    // add a separator
                }
                resultString += actValues[i].ToString();
            }
            ArduinoValues.GetComponent<Text>().text = resultString;       
         }

    }

    /// <summary>
    /// This is the function that will be called if the user presses the ActionButton
    /// </summary>
    public void MyAction(GameObject theButton)  // use the button itself as an argument
    {
        // example command
        if (!ledStatus)
        {
            myScript.commandToSend =  myScript.COMMAND + SET_LED_ON;
            ledStatus = true;
        }
        else
        {
            myScript.commandToSend = myScript.COMMAND + SET_LED_OFF;
            ledStatus = false;
        }
        Debug.Log("command = " + myScript.commandToSend);
    }

}

