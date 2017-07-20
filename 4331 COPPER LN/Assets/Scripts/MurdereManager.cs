using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurdereManager : MonoBehaviour
{
	public int speed;
	public GameObject player;
	private Rigidbody2D playerRigidbody;

	void Update () 
	{
		playerRigidbody = player.GetComponent<Rigidbody2D>();

		if (playerRigidbody.velocity.magnitude > 0) {
			Vector3 localPosition = player.transform.position - transform.position;
			localPosition = localPosition.normalized; // The normalized direction in LOCAL space
			transform.Translate (localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
		}

	}

}
