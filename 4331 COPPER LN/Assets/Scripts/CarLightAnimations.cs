using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLightAnimations : MonoBehaviour 
{
	public float timer;

	private Light lightning;


	// Use this for initialization
	IEnumerator Start () 
	{
		lightning = this.GetComponent<Light> ();

		while (true) 
		{
			yield return new WaitForSeconds(timer);
			lightning.enabled = !lightning.enabled;
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
