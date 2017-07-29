using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLevelManager : MonoBehaviour 
{

	public int playerMaxOil = 20;
	public int playerCurrentOil;
	public LightManager lighting;
	public ItemManager items;

	// Use this for initialization
	void Start () 
	{
		playerCurrentOil = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Make scene go dark when empty oil
		if(playerCurrentOil > 15)
		{
			lighting.SetToFull ();
		}

		if(playerCurrentOil > 10 && playerCurrentOil <= 15)
		{
			lighting.SetToThreeQtr ();
		}

		if(playerCurrentOil > 5 && playerCurrentOil <= 10)
		{
			lighting.SetToHalf ();
		}

		if(playerCurrentOil > 0 && playerCurrentOil <= 5)
		{
			lighting.SetToOneQtr ();
		}

		if(playerCurrentOil == 0)
		{
			lighting.SetToEmpty ();
		}
	}

	// Decrease amount of oil
	public void UseOil ()
	{
		if(playerCurrentOil > 0)
		{
			playerCurrentOil -= 1;	
		}
	}

	// Refill oil
	public void SetMaxOil ()
	{
		playerCurrentOil = playerMaxOil;
		items.PickupLantern ();

	}
		
}
