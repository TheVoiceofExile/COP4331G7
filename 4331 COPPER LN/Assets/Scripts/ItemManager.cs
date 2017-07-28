using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the players items
// - Keys unlock regular doors
// - Saw allows player to change floors
// - Master Key opens main doors
// - Front Door Key allows player ot leave house to win the game
public class ItemManager : MonoBehaviour 
{
	public int keysInHand;
	public bool axeInHand;
	public bool masterKeyInHand;
	public bool frontDoorKeyInHand;
	public bool lanternInHand;
	public bool masterBallInHand;


	// Use this for initialization
	void Start () 
	{
		keysInHand = 0;	
		axeInHand = false;
		masterKeyInHand = false;
		frontDoorKeyInHand = false;
		lanternInHand = false;
		masterBallInHand = false;
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

	public void PickupAxe ()
	{
		axeInHand = true;
	}

	public void PickupMasterKey ()
	{
		masterKeyInHand = true;
	}

	public void PickupFrontDoorKey ()
	{
		frontDoorKeyInHand = true;
	}

	public void PickupLantern ()
	{
		lanternInHand = true;
	}
}
