using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyMenuScript : MonoBehaviour {

    private SerialConnect mySerialScript;   // the script to do the actual connection and communication

    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform menuPanel;
    [SerializeField] GameObject StatusText;
    [SerializeField] GameObject ActionButton;
    [SerializeField] GameObject StateName;
    [SerializeField] GameObject ArduinoValues;

	// Use this for initialization
    void Start () {
        // find script
        mySerialScript = GetComponent<SerialConnect>();

        // find all comm ports
        if (mySerialScript != null) {
            // list all comm ports
            mySerialScript.PopulateComPorts();

            for (int i=0; i < SerialConnect.comPorts.Count; i++ )
            {
                // create a button for each comm port
                GameObject button = (GameObject)Instantiate(buttonPrefab);
                button.GetComponentInChildren<Text>().text = SerialConnect.comPorts[i]; 
                string arg = SerialConnect.comPorts[i]; // pass this string to the lambda function
                button.GetComponent<Button>().onClick.AddListener(
                    () => { MyOpenFunction(arg); }
                    );
                button.transform.parent = menuPanel;
            }
        }


	}

    /// <summary>
    /// The function to do the actual opening of a comm port
    /// </summary>
    /// <param name="arg">The string under which the comm port is known</param>
    void MyOpenFunction (string arg)
    {
        mySerialScript.CreateAndOpenConnection(arg);
    }
	
	// Update is called once per frame
	void Update () {
        // echo portStatus in StatusText
        StatusText.GetComponent<Text>().text = SerialConnect.portStatus;
        // make sure the button is only active when a comm port is open
        ActionButton.SetActive(SerialConnect.isPortActive);
        ArduinoValues.SetActive(SerialConnect.isPortActive);
    }


}
