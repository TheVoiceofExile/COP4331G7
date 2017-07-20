using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
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
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float vericalMove = Input.GetAxisRaw("Vertical");
        playerMoving = false;

		  if (cameraMovement.moving)
        {
            myRigidbody.velocity = new Vector2(0, 0);
            myAnimator.SetFloat("Horizontal", 0);
            myAnimator.SetFloat("Vertical", 0);
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

			  if (Mathf.Abs(horizontalMove) < 0.5f)
			  {
					myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
			  }

			  if (Mathf.Abs(vericalMove) < 0.5f)
			  {
					myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
			  }
		  }

        anim.SetFloat("MoveX", horizontalMove);
        anim.SetFloat("MoveY", vericalMove);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
