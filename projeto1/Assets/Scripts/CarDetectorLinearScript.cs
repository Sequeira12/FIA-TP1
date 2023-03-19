/*
Bruno Sequeira
Rui Santos
Tomás Dias
 */

using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorLinearScript : CarDetectorScript {

	public bool inverse = false;
	// Get gaussian output value

	public override float GetOutput()
	{

        //YOUR CODE HERE
        if (this.name == "CarDetectorLinearLeft")
            print("Left: " + output);
        if (this.name == "CarDetectorLinearRight")
            print("Right: " + output);
        return output;
	}





}
