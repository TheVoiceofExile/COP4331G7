using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public bool moving = false;
    public bool follow = false;
    public Transform player;

    private Transform cameraTarget;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraTarget.position, 300 * Time.deltaTime);
        }
        if (moving && transform.position == cameraTarget.position)
        {
            moving = false;
        }
    }

    void LateUpdate()
    {
        if (follow)
        {
            transform.position = player.position + offset;
        }
    }

    public void Move(Transform player, Transform cameraTarget, Transform playerTarget)
    {
        this.cameraTarget = cameraTarget;
        player.position = playerTarget.position;
        moving = true;
        follow = playerTarget.name == "HallwayPoint" ? true : false;
    }
}