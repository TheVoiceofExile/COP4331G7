using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour {

	public Transform cameraPosition;
	public Transform startPoint;
	public CameraMovement cameraMovement;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			cameraMovement.Move (other.transform, cameraPosition, startPoint);
			other.gameObject.GetComponent<OilLevelManager> ().UseOil ();
		}
	}
}
