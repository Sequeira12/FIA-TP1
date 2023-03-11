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
		
		cars = GetAllCars();


		output = 0;
		numObjects = cars.Length;
		float min = Mathf.Infinity;
		float distancia = 2;
		//percorre todos os carros possiveis
		foreach (GameObject car in cars)
		{
			distancia = (transform.position - car.transform.position).magnitude;

			if(distancia < min)
            {
				min = distancia;
				closestCar = car;
            }
		}
		output = distancia;
		
		
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
