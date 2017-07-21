using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItrigger : MonoBehaviour 
{
	public GameObject canvasObject;

	// Turns on the UI when entering house
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			canvasObject.SetActive (true);
		}
	}


}
