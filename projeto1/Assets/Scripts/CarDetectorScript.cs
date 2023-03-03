using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour
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
		// YOUR CODE HERE

		GameObject[] cars = null;
		GameObject closestCar = null;
		float dist = 0;
	


		if (useAngle)
		{
			cars = GetVisibleCars();
		}
		else
		{
			cars = GetAllCars();
		}

		output = 0;
		numObjects = cars.Length;

		//percorre todos os carros possiveis
		foreach (GameObject car in cars)
		{
			if (dist != 0)		// se for 0 é porque é o primeiro carro

			{
				//diferenca entre ele e o carro que está a seguir com os outros
				if (dist < Vector3.Distance(car.transform.position, transform.position))
				{
					
					dist = Vector3.Distance(car.transform.position, transform.position);
					
					closestCar = car;
				}
			}
			else //Primeira iteracao
			{
				dist = Vector3.Distance(car.transform.position, transform.position);
				closestCar = car;
			}
			output = 1 / (dist + 1);
		}
		
		
	}
	public virtual float GetOutput() { throw new NotImplementedException(); }

	// Retorna todos os objetos com a tag "CarToFollow". A tag do sensor não e tida em conta
	GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

	// YOUR CODE HERE

	GameObject[] GetVisibleCars()
	{
		ArrayList visibleCars = new ArrayList(); //carros detetadas
		float halfAngle = angle ; //obter apenas o lado da roda

		GameObject[] cars = GameObject.FindGameObjectsWithTag("CarToFollow");

		foreach (GameObject car in cars)
		{ //Percorrer todos os objetos desse campo de visao 
			Vector3 toVector = (car.transform.position - transform.position);
			Vector3 forward = transform.forward; //normalizar o vetor, da a magnitude
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle(forward, toVector);
			if (angleToTarget <= halfAngle)
			{//calcula se esse carro pertence ou nao ao angulo

				visibleCars.Add(car);
			}
		}

		return (GameObject[])visibleCars.ToArray(typeof(GameObject));
	}
}
