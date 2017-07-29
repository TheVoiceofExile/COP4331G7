using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightnightAnimation : MonoBehaviour 
{
	public float pause;
	public float flash1;
	public float flash2;
	public float flash3;

	private Light lightning;


	// Use this for initialization
	IEnumerator Start () 
	{
		lightning = this.GetComponent<Light> ();

		while (true) 
		{
			yield return new WaitForSeconds(pause);
			lightning.enabled = !lightning.enabled;
			yield return new WaitForSeconds(flash1);
			lightning.enabled = !lightning.enabled;
			yield return new WaitForSeconds(flash2);
			lightning.enabled = !lightning.enabled;
			yield return new WaitForSeconds(flash3);
			lightning.enabled = !lightning.enabled;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
