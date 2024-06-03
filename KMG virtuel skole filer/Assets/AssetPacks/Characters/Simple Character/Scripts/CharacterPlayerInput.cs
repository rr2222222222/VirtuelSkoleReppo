using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayerInput : MonoBehaviour
{
	static CharacterPlayerInput _instance;
	public static CharacterPlayerInput Instance
	{
		get
		{
			if (_instance == null)
				_instance = FindObjectOfType<CharacterPlayerInput>();

			return _instance;
		}
	}

	[Header("References")]
	public Transform cameraTransform;
	public Character character;

	[Header("Input")]
	public bool allowInput = true;

	Vector3 input;
	Vector3 flatForward;
	Vector3 flatRight;

	private void Awake()
	{
		if (cameraTransform == null)
			cameraTransform = Camera.main.transform;
	}

	private void OnDisable()
	{
		character.tankControlOverride = false;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			character.turnDirection = character.transform.forward;
		}
	}

	private void FixedUpdate()
	{
		if (allowInput)
		{
			input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

			character.tankControlOverride = !Input.GetMouseButton(1);
			character.run = Input.GetKey(KeyCode.LeftShift);

			if (Input.GetMouseButton(1))
			{
				flatForward = cameraTransform.forward;
				flatForward.y = 0f;
				flatForward.Normalize();

				flatRight = cameraTransform.right;
				flatRight.y = 0f;
				flatRight.Normalize();

				input = Vector3.ClampMagnitude(flatForward * input.z + flatRight * input.x, 1f);
			}

			character.input = input;
		}
	}

	public void SetAllowInput(bool value)
	{
		if (allowInput != value)
		{
			allowInput = value;

			if (value == false)
				character.input = Vector3.zero;
		}
	}

	public void SetCharacter(Character value)
	{
		if (character != value)
		{
			character.input = Vector3.zero;
			character = value;
		}
	}
}
