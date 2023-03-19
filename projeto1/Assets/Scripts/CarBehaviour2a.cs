/*
Bruno Sequeira
Rui Santos
Tomás Dias
 */

using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {




	void LateUpdate()
	{
		// YOUR CODE HERE
		float leftSensor = 0, rightSensor = 0,leftSensor1=0, rightSensor1=0;

		//Read sensor values

		if (DetectLights)
		{
			leftSensor1 = LeftLD.GetOutput();
			rightSensor1 = RightLD.GetOutput();
		}
		if (DetectCars)
        {
			leftSensor = LeftCD.GetOutput();
			rightSensor = RightCD.GetOutput(); 
		}
        if (DetectBlocks)
        {
			
			leftSensor = LeftBD.GetOutput();
			rightSensor = RightBD.GetOutput();
        }
		if(leftSensor1 > leftSensor && rightSensor1 > rightSensor)
        {
			m_LeftWheelSpeed = leftSensor1 * MaxSpeed;

			m_RightWheelSpeed = rightSensor1 * MaxSpeed;
		}
        else
        {
			m_LeftWheelSpeed = leftSensor * MaxSpeed;

			m_RightWheelSpeed = rightSensor * MaxSpeed;
		}

	}

}
