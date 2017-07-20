using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50;
    public CameraMovement cameraMovement;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    private static bool playerExists;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

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
                myRigidbody.velocity = new Vector2(horizontalMove * moveSpeed, myRigidbody.velocity.y);
            }

            if (Mathf.Abs(vericalMove) > 0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, vericalMove * moveSpeed);
            }

            if (Mathf.Abs(horizontalMove) < 0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

            if (Mathf.Abs(vericalMove) < 0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }

            myAnimator.SetFloat("Horizontal", horizontalMove);
            myAnimator.SetFloat("Vertical", vericalMove);
        }
    }
}