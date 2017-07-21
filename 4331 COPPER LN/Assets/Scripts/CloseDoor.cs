using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("An object has collided.");
		anim.SetTrigger ("Close");
	}
}
