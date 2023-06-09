using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")] public float movementSpeed;
    public float jumpForce;
    public float airMultiplier;
    private bool _canJump = true;

    public Transform orientation;
    public Animator _animator;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;
    private Rigidbody _rb;
    private bool _isGrounded;

    public float playerHeight;
    public LayerMask groundMask;
    public float groundDrag;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");


    public float SkillCD = 0;
    public float EffectCD = 0;
    public ParticleSystem FirstOne;
    public ParticleSystem SecondOne;


    private bool _isAreaSkillThrowing;
    [SerializeField] private int spellDamage;


    



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        SkillCD -= Time.deltaTime*1f;
        EffectCD -= Time.deltaTime * 1f;


        _isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, groundMask);
        MyInput();
        SpeedControl();

        if (_isGrounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = 0;
        }

        
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (_horizontalInput != 0 || _verticalInput != 0)
        {
            _animator.SetBool(IsWalking, true);
        }
        else
        {
            _animator.SetBool(IsWalking, false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && _canJump && _isGrounded)
        {
            Jump();
            _canJump = false;
            ResetJump();
        }

        if (SkillCD <= 0)
        {
            StartCoroutine(Skillx());
        }
        else
        {
            _animator.SetBool("IsSpelling", false);
        }

        if(EffectCD>=0)
        {
            FirstOne.Play();
            SecondOne.Play();
        }
        else
        {
            FirstOne.Stop();
            SecondOne.Stop();
            
        }
    }

    private void FixedUpdate()
    {
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

        if (_isGrounded)
        {
            // Movement
            _rb.velocity = new Vector3(_moveDirection.x * movementSpeed, _rb.velocity.y, _moveDirection.z * movementSpeed);
            _animator.SetBool(IsJumping,false);

        }
        else if (!_isGrounded)
        {
            // Air movement
            _rb.velocity = new Vector3(_moveDirection.x * movementSpeed, _rb.velocity.y, _moveDirection.z * movementSpeed);
            if (_rb.velocity.y < -0.1f && !_isGrounded)
            {
                // Falling
                _rb.velocity += Vector3.up * (Physics.gravity.y * (airMultiplier - 1) * Time.deltaTime);
            }
        }
        


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

    public bool IsGrounded()
    {
        return _isGrounded;
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        
        _animator.SetBool(IsJumping, true);
    }

    private void ResetJump()
    {
        _canJump = true;
    }

    private IEnumerator Skillx()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.SetBool("IsSpelling", true);
            Spell_AreaDamage();
            yield return new WaitForSeconds(2f);
            _isAreaSkillThrowing = false;
            EffectCD = 10;
            SkillCD = 30;
            
        }
    }

    private void Spell_AreaDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 6f);
        foreach (var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Damage(spellDamage);
            }
        }
    }
}