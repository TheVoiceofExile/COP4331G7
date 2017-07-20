using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorManager : MonoBehaviour 
{
	public KeyManager keyCount;
	public 

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player" && keyCount.keysInHand > 0)
		{
			this.transform.parent.gameObject.SetActive(false);
			other.gameObject.GetComponent<KeyManager> ().UseKey ();
		}
	}
}
