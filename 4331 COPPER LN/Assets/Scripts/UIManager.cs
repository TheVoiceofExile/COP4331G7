using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{

	public Slider oilBar;
	public Text keyText;
	public Image masterKey;
	public Image key;
	public Image axe;
	public Image frontDoorKey;
	public Image lantern;
	public Image masterBall;
	public OilLevelManager oilLevel;

	public ItemManager items;

	// Use this for initialization
	void Start () 
	{
		oilBar.gameObject.SetActive (false);
		keyText.gameObject.SetActive (false);
		axe.gameObject.SetActive (false);
		frontDoorKey.gameObject.SetActive (false);
		lantern.gameObject.SetActive (false);
		masterBall.gameObject.SetActive (false);
		masterKey.gameObject.SetActive (false);
		key.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
      	oilBar.maxValue = oilLevel.playerMaxOil;
      	oilBar.value = oilLevel.playerCurrentOil;
	  	keyText.text = "Keys: " + items.keysInHand;

		if(items.keysInHand > 0)
		{
			keyText.gameObject.SetActive (true);
			key.gameObject.SetActive (true);
		}

		if(items.masterKeyInHand == true)
		{
			masterKey.gameObject.SetActive (true);
		}

		if(items.frontDoorKeyInHand == true)
		{
			frontDoorKey.gameObject.SetActive (true);
		}

		if(items.axeInHand == true)
		{
			axe.gameObject.SetActive (true);
		}

		if(items.lanternInHand == true)
		{
			lantern.gameObject.SetActive (true);
			oilBar.gameObject.SetActive (true);
		}


	}


}
