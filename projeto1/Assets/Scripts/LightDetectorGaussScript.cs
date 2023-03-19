/*
Bruno Sequeira
Rui Santos
Tomás Dias
 */

using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Runtime.InteropServices;

public class LightDetectorGaussScript : LightDetectorScript {

	public float stdDev = 0.12f; 
	public float mean = 0.5f; 
	public float min_y;
	public bool inverse = false;

    public override float GetOutput()
    {
        //Formula de Gauss 
        float aux = (float)(1.0f / (stdDev * Math.Sqrt(2.0f * Math.PI)));
        float outp = (float)(aux * Math.Exp(-0.5f * Math.Pow(output - mean, 2) / Math.Pow(stdDev, 2)));


        //quando os limiares estao ativos
        if (ApplyThresholds)
        {
            if(outp > MaxX || outp < MinX)
            {
                outp = 0;
            }
        }
        //quando os limites estao ativos
        if (ApplyLimits)
        {
            if(outp > MaxY)
            {
                outp = MaxY;
            }
            if(outp < MinY)
            {
                outp = MinY;
            }
        }
        if (this.name == "LightDetectorGaussLeft")
            print("Left: " + outp);
        if (this.name == "LightDetectorGaussRight")
            print("Right: " + outp);
        return outp;
    }
}
