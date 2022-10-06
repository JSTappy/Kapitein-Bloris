/**
 * SerialConnect.cs
 * 
 * Copyright 2014 Rik Teerling
 * 
 * A Unity/Mono class to send and receive values to and from the serial port
 * 
 * Due to a bug in Mono, System.IO.Ports doesn't trigger a "Hey, we received something on the serial port" event. That sucks monkeyballs.
 * Workaround: initiate the data transfer yourself from Unity by sending the char 'a' to Arduino every (nth) frame
 * The string expected back is a series of ints, separated by commas (',')
 * Individual values are split into a public list aptly named 'values'
 * 
 * Instructions:
 * - upload Arduino sketch to Arduino/Teensy (see below)
 * - Add this script to an empty GameObject
 * - Unity -> Edit -> Project Settings -> Player -> Other Settings -> .net 2.0 (no subset)
 * - Select GameObject and watch values in inspector
*/

// Arduino sketch:
/*
void setup()
{
	Serial.begin(115200);
}

void loop()
{
	if(Serial.available()) {
		char inByte = Serial.read();

		if (inByte == 'a') {
			int adc0 = analogRead(A0);
			int adc1 = analogRead(A1);

			// construct string from read values
			String s0 = "";
			String s1 = s0 + adc0;
			String s2 = s1 + ",";
			String s3 = s2 + adc1;

			Serial.println(s3);
		}
	}
}
*/

using UnityEngine;
using System.Collections.Generic;
using System.IO.Ports;
using System;

public class SerialConnect : MonoBehaviour
{
    private const string GIVE_INPUT = "a";  // signal to the Arduino that we want to receive data
    public string COMMAND = "b";

    public string port = "COM3";
	public int baudrate = 115200;           // set to maximum baudrate

	public int n = 6; // every nth frame, do a data transfer on the serial port (n can be 1)
	public int timeout = 1000; // sets the serial timeout value before reporting error

	public List<int> values = new List<int>(); // our list of received values
	public string commandToSend = "";			// to send commands to the Arduino

	//Setup parameters to connect to the serial port
	private static SerialPort serial;
    public static string portStatus = "";  // can be used for debugging or status
	private static string incoming;         // the string coming from the serial port
	private static int counter = 0;         // framecounter needed for calculating when to send a 'command'
    
    // List of all com ports available on the system
    public static List<string> comPorts = new List<string>();
    public static bool isPortActive = false;    // true = a comm port is opened

    void Start()
	{
        // Open the selected serial port
		//serial = new SerialPort(port, baudrate, Parity.None, 8, StopBits.One);
		//OpenConnection();
	}


	void Update()
	{
        if (isPortActive)
        {
            if (counter % n == 0)
            {
                if (commandToSend != "")
                {
                    // send command to Arduino
                    serial.Write(commandToSend);
                    commandToSend = "";	// reset command to send
                }
                else
                {
                    // signal that we want to receive values
                    serial.Write(GIVE_INPUT);
                    try
                    {
                        incoming = serial.ReadLine();
                        ParseLine(incoming);
                        portStatus = "Normal operation";
                    }
                    catch (TimeoutException e)
                    {
                        //print ("TimeoutException (try resetting connected device) " + e);
                        portStatus = "TimeoutException (try resetting connected device) ";  // +e;
                    }
                }
            }
            counter++;
            //Debug.Log (values[0]);

        }
	}


	void ParseLine(string strIn)
	{
		string[] svalues = strIn.Split(',');
		List<int> list = new List<int>();
		foreach (string svalue in svalues) {
			int numVal = Convert.ToInt32(svalue);
			list.Add(numVal);
		}
		values = list;
	}

    /// <summary>
    /// This function creates a serial port connection for the given commPortName
    /// Will be called from another script
    /// </summary>
    /// <param name="commPortName"></param>
    public void CreateAndOpenConnection(string commPortName)
    {
        // Gidi: before we create a SerialPort, first check if it already was created before
        if (serial != null)
        {
            if (serial.IsOpen)
            {
                serial.Close();
                isPortActive = false;
            }
        }
        // create the serial port
        serial = new SerialPort(commPortName, baudrate, Parity.None, 8, StopBits.One);
        // now try to open the connection
        OpenConnection();
    }

	public void OpenConnection()
	{
		if (serial != null) {
			if (serial.IsOpen) {
				serial.Close();
				// print("Closing port, because it was already open!");
                portStatus = "Closing port, because it was already open!";
                isPortActive = false;
			} else {
				serial.Open();
				serial.ReadTimeout = timeout;
				// print("Port Opened!");
                portStatus = "Port "+ serial.PortName + " opened!";
                isPortActive = true;
			}
		} else {
			//print("Port == null");
            portStatus = "Port == null";
		}
	}


	void OnApplicationQuit()
	{
        if (serial != null)
        {
            serial.Close();
        }
	}

    /// <summary>
    /// Function that utilises system.io.ports.getportnames() to populate
    /// a list of com ports available on the system.
    /// Will be called from another script
    /// </summary>
    public void PopulateComPorts()
    {
        Debug.Log("PopulateComPorts");

        comPorts.Clear();       // reset

        int p = (int)System.Environment.OSVersion.Platform;

        // Are we on Unix?
        if (p == 4 || p == 128 || p == 6)
        {
            string[] ttys = System.IO.Directory.GetFiles("/dev/", "tty.*");
            foreach (string dev in ttys)
            {
                if (dev.StartsWith("/dev/tty."))
                {
                    if (dev != "/dev/tty")
                    {
                        comPorts.Add(dev);
                        Debug.Log(dev.ToString());
                    }
                }
            }
        }
        else
        {   // on Windows
            // Loop through all available ports and add them to the list
            foreach (string cPort in System.IO.Ports.SerialPort.GetPortNames())
            {
                comPorts.Add(cPort);
                Debug.Log(cPort.ToString());
            }
        }

        if (comPorts.Count == 0)
        {
            portStatus = "No CommPort available";
        }
        else
        {
            // Update the port status just in case :)
            portStatus = "# of CommPorts = " + comPorts.Count.ToString();
        }
    }

}
