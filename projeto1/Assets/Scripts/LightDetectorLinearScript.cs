/*
Bruno Sequeira
Rui Santos
Tomás Dias
 */

using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorLinearScript : LightDetectorScript {

	public override float GetOutput()
	{  
        //quando os limiares estao ativos
        if (ApplyThresholds)
        {
            if (output > MaxX || output < MinX)
            {
                output = MinY;
            }
        }
        //quando os limites estao ativos
        if (ApplyLimits)
        {
            if (output > MaxY)
            {
                output = MaxY;
            }
            if (output < MinY)
            {
                output = MinY;
            }
        }
        return output;
	}

}
