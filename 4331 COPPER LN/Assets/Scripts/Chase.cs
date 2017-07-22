using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
	public int speed;
	public GameObject player;
	private Rigidbody2D myRigidbody;
	
	void Start ()
	{
		myRigidbody = player.GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		if (myRigidbody.velocity.magnitude > 0) {
			Vector3 localPosition = player.transform.position - transform.position;
			localPosition = localPosition.normalized; // The normalized direction in LOCAL space
			transform.Translate (localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
		}

	}

}
