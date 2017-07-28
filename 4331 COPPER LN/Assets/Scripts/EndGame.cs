using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour 
{
	public ItemManager frontDoorKey;
	public GameObject textBox;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			if (frontDoorKey.frontDoorKeyInHand == true) {
				Debug.Log ("Triggered");
				this.gameObject.SetActive(false);
				other.GetComponent<PlayerController> ().canMove = false;
				textBox.GetComponent<TextBoxManager> ().EnableTextBox ();
			} 
		}
	}
}
