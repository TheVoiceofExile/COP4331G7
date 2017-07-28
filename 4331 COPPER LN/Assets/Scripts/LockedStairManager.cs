using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Manages whether the player can change floors or not.
// When the player is holding the Saw, they can remove
// the blocks to change stairs. Saw is not a usable item,
// but rather once they pick it up they can reuse it.
public class LockedStairManager : MonoBehaviour 
{
	public ItemManager axe;
	public GameObject textBox;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			if(axe.axeInHand == true)
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
