using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorManager : MonoBehaviour 
{
	public ItemManager frontDoorKey;
	public GameObject textBox;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			if(frontDoorKey.frontDoorKeyInHand == true)
			{
				this.transform.parent.gameObject.SetActive(false);
			} else {
				other.GetComponent<PlayerController> ().canMove = false;
				Debug.Log("Triggered");
				textBox.GetComponent<TextBoxManager> ().EnableTextBox ();
			}

		}
	}
}
