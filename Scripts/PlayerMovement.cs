using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _forwardSpeed;

	[SerializeField] private float _horizontalSpeed;

	[SerializeField] private Rigidbody _rigidbody;

	[SerializeField] private bool isOnGround = true;

	[SerializeField] private float jumpPower;

    private Vector3 _velocity = new Vector3();

	public float maxHorizontalDistance;

	private void Start()
	{
		
	}

	private void Update()
	{
		_velocity.z = _forwardSpeed;
		_velocity.y = _rigidbody.velocity.y;
		_velocity.x = Input.GetAxis("Horizontal") * _horizontalSpeed;

		if (Input.GetKeyDown(KeyCode.Space)&&isOnGround)
		{
			_rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
			isOnGround = false;
		}
	}

    private void OnCollisionEnter(Collision collision)
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