using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour 
{
	public int keysInHand;

	// Use this for initialization
	void Start () 
	{
		keysInHand = 0;		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Decrease amount of keys
	public void UseKey ()
	{
		if(keysInHand > 0)
		{
			keysInHand -= 1;	
		}
	}

	// Pickup key
	public void PickupKey ()
	{
		keysInHand++;
	}

}
