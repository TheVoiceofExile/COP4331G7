using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public bool moving = false;

	private Transform cameraTarget;
	
	// Update is called once per frame
	void Update ()
	{
		if(moving)
		{
			transform.position = Vector3.MoveTowards (transform.position, cameraTarget.position, 300 * Time.deltaTime);
		}
		if(moving && transform.position == cameraTarget.position)
		{
			moving = false;
		}
	}

	public void Move(Transform player, Transform cameraTarget, Transform playerTarget)
	{
		this.cameraTarget = cameraTarget;
		player.position = playerTarget.position;
		moving = true;
	}
}
