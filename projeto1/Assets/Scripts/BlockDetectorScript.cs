using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class BlockDetectorScript : MonoBehaviour
{

	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	private bool useAngle = true;

	public float output;
	public int numObjects;

	void Start()
	{
		output = 0;
		numObjects = 0;

		if (angle > 360)
		{
			useAngle = false;
		}
	}

	void Update()
	{
		GameObject[] blocos;
		blocos = GetAllBlocks();
		GameObject closestBlock = null;
		
		output = 0;
		numObjects = blocos.Length;
		float min = Mathf.Infinity;
		float distancia = 10;

		//percorre todos os blocos possiveis


		

		foreach (GameObject bloco in blocos)
		{
			//distancia entre bloco e carro
			distancia = (bloco.transform.position - transform.position).sqrMagnitude;
			
			if (distancia < min)
			{
				min = distancia;
				closestBlock = bloco;
			}
		}
		output = distancia;

	}

	public virtual float GetOutput() { throw new NotImplementedException(); }

	// Returns all "Blocos" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllBlocks()
	{
		return GameObject.FindGameObjectsWithTag("BlocoScape");
	}

	// Returns all "Blocos" tagged objects that are within the view angle of the Sensor.
	GameObject[] GetVisibleBlocks()
	{
		ArrayList visibleCars = new ArrayList(); //carros detetadas
		float halfAngle = angle; //obter apenas o lado da roda

		GameObject[] Blocos = GameObject.FindGameObjectsWithTag("BlocoScape");

		foreach (GameObject bloc in Blocos)
		{ //Percorrer todos os objetos desse campo de visao 
			Vector3 toVector = (bloc.transform.position - transform.position);
			Vector3 forward = transform.forward; //normalizar o vetor, da a magnitude
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle(forward, toVector);
			if (angleToTarget <= halfAngle)
			{//calcula se esse carro pertence ou nao ao angulo

				visibleCars.Add(bloc);
			}
		}

		return (GameObject[])visibleCars.ToArray(typeof(GameObject));
	}

}