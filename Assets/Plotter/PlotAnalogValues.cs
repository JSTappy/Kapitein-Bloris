using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlotAnalogValues : MonoBehaviour {

    [SerializeField] GameObject objectWithSerialConnect;        // the object to which the SerialConnect script is attached

    private List<int> actValues;
	private SerialConnect myScript;

	// Use this for initialization
	void Start () {
        myScript = objectWithSerialConnect.GetComponent<SerialConnect>();
		actValues = myScript.values;

        //  Create a new graph named "Analog0", with a range of 0 to 1024, colour green at position 100,100
        PlotManager.Instance.PlotCreate("Analog0", -1024, 1024, Color.green, new Vector2(100,100));

        // Create a new child "Analog1" graph.  Colour is red and parent is "Analog0"
        PlotManager.Instance.PlotCreate("Analog1", Color.red, "Analog0");

        // Create a new child "Analog2" graph.  Colour is blue and parent is "Analog0"
        PlotManager.Instance.PlotCreate("Analog2", Color.blue, "Analog0");

        // Create a new child "Analog3" graph.  Colour is cyan and parent is "Analog0"
        PlotManager.Instance.PlotCreate("Analog3", Color.cyan, "Analog0");

    }

    // Update is called once per frame
    void Update () {

		// get values 
		actValues = myScript.values;
		if (actValues.Count > 0) {
			// Add data to graphs
			PlotManager.Instance.PlotAdd("Analog0", actValues[0]);  
		}
        if (actValues.Count > 1)
        {
            // Add data to graphs
            PlotManager.Instance.PlotAdd("Analog1", actValues[1] - 100); // Gidi: 100 = offset
        }
        if (actValues.Count > 2)
        {
            // Add data to graphs
            PlotManager.Instance.PlotAdd("Analog2", actValues[2] - 200);
        }
        if (actValues.Count > 3)
        {
            // Add data to graphs
            PlotManager.Instance.PlotAdd("Analog3", actValues[3] - 300);
        }

    }


}
