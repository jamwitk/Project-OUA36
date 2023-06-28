using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraStyle
{
    Basic,
    Combat
}
public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform combatOrientation;
    public Transform player;
    public Transform playerObject;
    public float rotationSpeed;
    public CameraStyle currentStyle;
    public GameObject basicCam;
    public GameObject combatCam;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if(Input.GetMouseButton(1))
        {
            basicCam.SetActive(false);
            combatCam.SetActive(true);
            // var dirToCombatOrientation =  combatOrientation.position - new Vector3(transform.position.x, combatOrientation.position.y, transform.position.z);
            // orientation.forward = dirToCombatOrientation.normalized;
            playerObject.forward = Vector3.Slerp(playerObject.forward, inputDir.normalized, rotationSpeed * Time.deltaTime * rotationSpeed);
        }
        else
        {
            basicCam.SetActive(true);
            combatCam.SetActive(false);
            if (inputDir.magnitude > 0.1f)
            {
                playerObject.forward = Vector3.Slerp(playerObject.forward, inputDir.normalized, rotationSpeed * Time.deltaTime * rotationSpeed);
            }
        }
        orientation.forward = viewDir.normalized;

    }
}
