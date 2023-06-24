using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Transform orientation;
    
    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;
    private Rigidbody _rb;
    public Animator _animator;
    private bool _isGrounded;
    
    public float playerHeight;
    public LayerMask groundMask;
    public float groundDrag;
    
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.5f, groundMask);
        
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        SpeedControl();
        
       
        
        
        if (_isGrounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = 0;
        }
        
        //animaton
        if(_horizontalInput != 0 || _verticalInput != 0)
        {
            _animator.SetBool(IsWalking, true);
        }
        else
        {
            _animator.SetBool(IsWalking, false);
        }

    }

    private void FixedUpdate()
    {
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;
        
        _rb.velocity = new Vector3(_moveDirection.x * movementSpeed, _rb.velocity.y, _moveDirection.z * movementSpeed);
    }

    private void SpeedControl()
    {
        var flatVelocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        if (flatVelocity.magnitude > movementSpeed)
        {
            var newVelocity = flatVelocity.normalized * movementSpeed;
            _rb.velocity = new Vector3(newVelocity.x, _rb.velocity.y, newVelocity.z);
        }
    }
}