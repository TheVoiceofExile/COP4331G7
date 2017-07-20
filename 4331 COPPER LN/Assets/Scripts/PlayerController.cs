using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
	public CameraMovement cameraMovement;

    private Animator anim;
    private Rigidbody2D myRigidBody;
	private Vector2 lastMove;

	private static bool playerExists;
    private bool playerMoving;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();

		if (!playerExists)
		{
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {

        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            // transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, myRigidBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            // transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * speed);
            playerMoving = true;
            lastMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

		float horizontalMove = Input.GetAxisRaw("Horizontal");
		float vericalMove = Input.GetAxisRaw("Vertical");
		playerMoving = false;

		if (cameraMovement.moving)
		{
			myRigidBody.velocity = new Vector2(0, 0);
			anim.SetFloat("Horizontal", 0);
			anim.SetFloat("Vertical", 0);
		}
		else
		{
			if (Mathf.Abs(horizontalMove) > 0.5f)
	        {
				myRigidBody.velocity = new Vector2(horizontalMove * speed, myRigidBody.velocity.y);
	            playerMoving = true;
				lastMove = new Vector2(horizontalMove, 0);
	        }

			if (Mathf.Abs(vericalMove) > 0.5f)
	        {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, vericalMove * speed);
	            playerMoving = true;
				lastMove = new Vector2(0, vericalMove);
	        }

			if(Mathf.Abs(horizontalMove) < 0.5f)
	        {
	            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
	        }

			if (Mathf.Abs(vericalMove) < 0.5f)
	        {
	            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
	        }

			anim.SetFloat("MoveX", horizontalMove);
			anim.SetFloat("MoveY", vericalMove);
	        anim.SetBool("PlayerMoving", playerMoving);
	        anim.SetFloat("LastMoveX", lastMove.x);
	        anim.SetFloat("LastMoveY", lastMove.y);
		}

    }
}
