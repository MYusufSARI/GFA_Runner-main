using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;

    [SerializeField] private float _horizontalSpeed;

    [SerializeField] private Rigidbody _rigidbody;


    

    [SerializeField] private float jumpPower;

    

    public float JumpPower
    {
        get => jumpPower;

        set => jumpPower = value;
    }

    private Vector3 _velocity = new Vector3();

    public Vector3 Velocity => _rigidbody.velocity;

    public float maxHorizontalDistance;

    private bool isOnGround = true;

    public bool IsGrounded => isOnGround;

    public event Action Jumped;

    void Update()
    {
        if (!GameInstance.Instance.IsGameStarted)
        {
            _velocity = Vector3.zero;
            return;
        }

        _velocity.z = _forwardSpeed;
        _velocity.y = _rigidbody.velocity.y;
        _velocity.x = Input.GetAxis("Horizontal") * _horizontalSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            
            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            Jumped?.Invoke();

            isOnGround = false;
        }


    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_rigidbody.position.x) > maxHorizontalDistance)
        {
            var clampedPosition = _rigidbody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxHorizontalDistance, maxHorizontalDistance);

            _rigidbody.position = clampedPosition;
        }


        _rigidbody.velocity = _velocity;


    }
}