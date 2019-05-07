using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
	int distance = 3;
	public Track previous;
	new public Renderer light;
	Collider train = null;

	void SetDistance(int toTrain)
	{
		distance = toTrain;

		if (previous != null && train == null)
		{
			previous.SetDistance(toTrain + 1);
		}
	}

    void OnTriggerEnter(Collider collider)
    {
		train = collider;
    }

    void OnTriggerExit(Collider collider)
    {
		train = null;
		SetDistance(0);
    }

	void Update()
	{
		switch (distance)
		{
			case 0:
			case 1:
				light.material.color = Color.red;
				break;
			case 2:
				light.material.color = Color.yellow;
				break;
			default:
				light.material.color = Color.green;
				break;
		}
	}
}
