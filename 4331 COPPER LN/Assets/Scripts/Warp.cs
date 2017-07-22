using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	public Transform warpTargetPlayer;
	public Transform warpTargetCamera;

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

		yield return StartCoroutine(sf.FadeToBlack());

		// Camera to Startpoint, player to StartPoint and Z = 0
		other.gameObject.transform.position = warpTargetPlayer.position;
		Camera.main.transform.position = warpTargetCamera.position;

		yield return StartCoroutine(sf.FadeToClear());
	}
}
