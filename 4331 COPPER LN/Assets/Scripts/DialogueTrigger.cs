using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour 
{
	public GameObject textBox;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			other.GetComponent<PlayerController> ().canMove = false;
			Debug.Log("Triggered");
			textBox.GetComponent<TextBoxManager> ().EnableTextBox ();
			Destroy (gameObject);
		}
	}
}
