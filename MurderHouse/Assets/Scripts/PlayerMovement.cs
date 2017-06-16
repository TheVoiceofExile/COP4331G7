using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed = 50;
	public CameraMovement cameraMovement;

	private Rigidbody2D myRigidbody;

	private static bool playerExists;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();

		if(!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(cameraMovement.moving)
		{
			myRigidbody.velocity = new Vector2 (0, 0);
		}
		else
		{
			if(Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f)
			{
				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, myRigidbody.velocity.y);
			}	

			if(Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
			}	

			if(Mathf.Abs (Input.GetAxisRaw ("Horizontal")) < 0.5f)
			{
				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
			}

			if(Mathf.Abs (Input.GetAxisRaw ("Vertical")) < 0.5f)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
			}
		}
	}
}
