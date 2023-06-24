using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObject;
    public Rigidbody rb;
    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if(inputDir.magnitude > 0.1f)
        {
            playerObject.forward = Vector3.Slerp(playerObject.forward, inputDir.normalized, rotationSpeed * Time.deltaTime * rotationSpeed);

        }
    }
}
