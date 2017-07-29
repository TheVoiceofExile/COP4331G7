using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorManager : MonoBehaviour 
{
	public ItemManager keyCount;
	public GameObject textBox;

	public bool isMaster;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			if(!isMaster)
			{
				if(keyCount.keysInHand > 0)
				{
					this.transform.parent.gameObject.SetActive(false);
					other.gameObject.GetComponent<ItemManager> ().UseKey ();
				} else {
					other.GetComponent<PlayerController> ().canMove = false;
					Debug.Log("Triggered");
					textBox.GetComponent<TextBoxManager> ().EnableTextBox ();
				}
			} else {
				if(keyCount.masterKeyInHand == true)
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
}
