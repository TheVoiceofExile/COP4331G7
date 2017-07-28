using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour 
{

	public GameObject textBox;
	public GameObject item;

	void OnTriggerEnter2D (Collider2D other)
	{

		if(other.gameObject.name == "Player")
		{
			this.gameObject.SetActive(false);
			item.SetActive (true);
			other.GetComponent<PlayerController> ().canMove = false;
			Debug.Log("Triggered");
			textBox.GetComponent<TextBoxManager> ().EnableTextBox ();

		}
	}

}
