using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

		Debug.Log("An object has collided.");

		yield return StartCoroutine(sf.FadeToBlack());

		other.gameObject.transform.position = new Vector3(warpTarget.position.x, warpTarget.position.y, 0);
		Camera.main.transform.position = warpTarget.position;

		yield return StartCoroutine(sf.FadeToClear());


	}
}
