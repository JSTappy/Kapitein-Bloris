using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class Moving : SerialConnect
{
    public GameObject Balloon;
   //THIS SHOULD BE MOVED TO ITS OWN SCRIPT WHEN EVERYTHING IS WORKING CORRECTLY
    public override void BalloonMove()
    {
        //Converts the incoming Println string to an int
        int numVal = Convert.ToInt32(serial.ReadLine());

        //Moves the balloon up and down based on the incoming value (hard limits, needs to hit a number and then it will go up or down).
        //This is inconsistent due to the fact that the chip is not immeadiately sending the value. The chip is rather slow and because of that the value will slowly down.
        //This will result in an empty balloon in the real world while the in game balloon isgrowing and going up
        if (numVal > 20)
        {
            Balloon.transform.Translate(Vector3.up * 24 * Time.deltaTime);
        }
        else
        {
            Balloon.transform.Translate(Vector3.down * 24 * Time.deltaTime);
        }
        
    }

}
