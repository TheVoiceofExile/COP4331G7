using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 1f;
	
	private Rigidbody2D body;

	// Use this for initialization
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update()
	{
		body.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f),
		                            Mathf.Lerp(0, Input.GetAxis("Vertical") * speed, 0.8f));
	}
}
