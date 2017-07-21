using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour 
{
	public Transform newCamPosition;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			Camera.main.transform.position = newCamPosition.position;
		}
	}

}
