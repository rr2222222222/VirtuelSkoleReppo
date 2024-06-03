using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public Vector3 input = Vector3.zero;
	public Vector3 turnDirection;
	public bool run = false;
	public bool tankControlOverride = false;
	public bool boostWalk = false;

	float acceleration = 3f;
	float turnSpeed = 5f;
	float turnThreshold = 0.5f;
	float tankTurnSpeed = 180;
	float boostSpeed = 0.25f;

	float moveForward;
	float moveForwardBoost;

	Animator animator;
	new Rigidbody rigidbody;

	private void Awake()
	{
		animator = GetComponentInChildren<Animator>();

		rigidbody = GetComponent<Rigidbody>();
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

		turnDirection = transform.forward;
	}

	void FixedUpdate()
	{
		input = Vector3.ClampMagnitude(input, 1f);

		if (tankControlOverride)
		{
			if (boostWalk)
			{
				if (input.sqrMagnitude > 0.001f)
					moveForwardBoost = Mathf.MoveTowards(moveForwardBoost, 1f, Time.deltaTime * boostSpeed);
				else
					moveForwardBoost = Mathf.MoveTowards(moveForwardBoost, 0f, Time.deltaTime);
			}

			moveForward = Mathf.Lerp(moveForward, input.z * (run ? 3 : 1 + moveForwardBoost), Time.deltaTime * acceleration);
			rigidbody.MoveRotation(Quaternion.Euler(transform.localEulerAngles + Vector3.up * Time.deltaTime * input.x * tankTurnSpeed));
		}
		else
		{
			if (input.sqrMagnitude > 0.001f)
			{
				turnDirection = input;
				turnDirection.y = 0f;
				turnDirection.Normalize();
			}

			if (boostWalk)
			{
				if (input.sqrMagnitude > 0.001f)
					moveForwardBoost = Mathf.MoveTowards(moveForwardBoost, 1f, Time.deltaTime * boostSpeed);
				else
					moveForwardBoost = Mathf.MoveTowards(moveForwardBoost, 0f, Time.deltaTime);
			}

			moveForward = Mathf.Lerp(moveForward, input.magnitude * Mathf.Max(turnThreshold, Vector3.Dot(turnDirection, transform.forward) * (run ? 3 : 1 + moveForwardBoost)), Time.deltaTime * acceleration);
			rigidbody.MoveRotation(Quaternion.Lerp(rigidbody.rotation, Quaternion.LookRotation(turnDirection, Vector3.up), Time.deltaTime * turnSpeed));
		}

		animator.SetFloat("Forward", moveForward);
	}
}
