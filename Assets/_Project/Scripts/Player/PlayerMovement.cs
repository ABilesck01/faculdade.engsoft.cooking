using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField]private Transform cam;
    
    private CharacterController _characterController;
    private float _turnSmoothVelocity;
    private Transform _transform;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,
                turnSpeed);
            
            _transform.rotation = Quaternion.Euler(0, angle, 0);
            
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            
            _characterController.Move(Time.deltaTime * moveSpeed * moveDir.normalized);
        }
        Animate(direction.magnitude);
    }

    private void Animate(float speed)
    {
        _animator.SetFloat($"speed", speed);
    }
}
