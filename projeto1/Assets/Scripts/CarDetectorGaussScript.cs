using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorGaussScript : CarDetectorScript
{

	public float stdDev = 0.5f;
	public float mean = 0.0f;
	// Get gaussian output value
	public override float GetOutput()
	{
		// YOUR CODE HERE
		MaxY = 0.15f;
		MinY = 0.1f;
		MaxX = 0;
		MinX = 1;

		if (MaxY > output)
		{
			mean = 0.0f;
			stdDev = .5f;
		}
		else if (MinY < output)
		{
			mean = 0.0f;
			stdDev = 0.12f;
		}


		//Formula de Gauss dada na aula
		float a = (float)(1 / (stdDev * Math.Sqrt(2.0 * Math.PI)));
		float fx = (float)(a * Math.Exp(-0.5f * Math.Pow(output - mean, 2) / Math.Pow(stdDev, 2)));


		return fx;
	}


}