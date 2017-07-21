using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilRefill : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			other.gameObject.GetComponent<OilLevelManager> ().SetMaxOil ();
			gameObject.SetActive (false);
		}
	}
}
