using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Manages the lighting of torches
public class TorchManager : MonoBehaviour 
{
	public GameObject textBox;
	public GameObject lit;
	public Light lightSource;
	public OilLevelManager oil;

	public bool isLit;

	// Called at beggining of game
	void Start ()
	{
		if(!isLit)
		{
			lightSource.enabled = false;
			lit.SetActive (false);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.name == "Player" && oil.playerCurrentOil > 0)
		{
			// Change to lit sprite and turn on lightsource
			this.gameObject.SetActive(false);
			lit.SetActive (true);
			lightSource.enabled = true;

			// Use five oil
			oil.UseOil ();
			oil.UseOil ();
			oil.UseOil ();
			oil.UseOil ();
			oil.UseOil ();

			// Dialogue
			other.GetComponent<PlayerController> ().canMove = false;
			textBox.GetComponent<TextBoxManager> ().EnableTextBox ();
		}
	}
}
