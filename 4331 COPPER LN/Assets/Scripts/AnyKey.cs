using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKey : MonoBehaviour {

	private bool start = true;
	public Transform warpTarget;


	// Update is called once per frame
	void Update () 
	{

		if(Input.anyKey && start)
		{
			Debug.Log("A key or mouse click has been detected.");

			Camera.main.transform.position = warpTarget.position;

			start = false;
		}
	}
}
