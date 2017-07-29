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
	public GameObject blockedDialogue;
	public GameObject removeDialogue;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			if(axe.axeInHand == true)
			{
				this.transform.parent.gameObject.SetActive(false);
				other.GetComponent<PlayerController> ().canMove = false;
				removeDialogue.GetComponent<TextBoxManager> ().EnableTextBox ();

			} else {
				other.GetComponent<PlayerController> ().canMove = false;
				Debug.Log("Triggered");
				blockedDialogue.GetComponent<TextBoxManager> ().EnableTextBox ();
			}

		}
	}
}
