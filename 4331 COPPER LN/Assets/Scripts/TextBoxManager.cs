using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour 
{
	private bool isActive;

	public PlayerController player;

	void Start ()
	{
		isActive = false;
		gameObject.SetActive(false);
	}
		
	void Update ()
	{
		if(isActive)
		{
			if(Input.GetKey(KeyCode.Space))
			{
				Debug.Log("Space");
				DisableTextBox ();
			}
		}
	}

	public void EnableTextBox()
	{
		Debug.Log("Enabled");
		gameObject.SetActive(true);
		isActive = true;

	}

	public void DisableTextBox()
	{
		Debug.Log("Disabled");
		gameObject.SetActive(false);
		isActive = false;
		player.canMove = true;
//		Destroy (gameObject);
	}

}