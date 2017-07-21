using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider oilBar;
	public Text keyText;
	public OilLevelManager oilLevel;
	public KeyManager keyCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		oilBar.maxValue = oilLevel.playerMaxOil;
		oilBar.value = oilLevel.playerCurrentOil;
		keyText.text = "Keys: " + keyCount.keysInHand;
	}
}
