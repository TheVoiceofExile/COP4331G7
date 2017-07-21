using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLevelManager : MonoBehaviour 
{

	public int playerMaxOil = 10;
	public int playerCurrentOil;

	// Use this for initialization
	void Start () 
	{
		playerCurrentOil = playerMaxOil;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Make scene go dark when empty oil
		if(playerCurrentOil == 0)
		{
			
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
	}
		
}
