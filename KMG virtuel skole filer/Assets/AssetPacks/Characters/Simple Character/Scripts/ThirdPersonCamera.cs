using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	static ThirdPersonCamera _instance;
	public static ThirdPersonCamera Instance
	{
		get
		{
			if (_instance == null)
				_instance = FindObjectOfType<ThirdPersonCamera>();

			return _instance;
		}
	}

	[Header("References")]
	public Transform followTarget;
	public Transform characterTransform;

	[Header("Collision")]
	public LayerMask collisionLayerMask;

	[Header("Input")]
	public bool allowInput = true;

	float zoomMinZ = -5f;
	float zoomMaxZ = -1f;
	float zoomSpeed = 0.5f;

	float pitchMin = -60f;
	float pitchMax = 60f;
	float pitchSpeed = 3f;

	float yawSpeed = 3f;

	float resetYawSpeed = 5f;

	Vector3 cameraLocalPosition;
	Vector3 parentLocalEulerAngles;

	new Camera camera;

	private void Awake()
	{
		cameraLocalPosition = transform.localPosition;
		parentLocalEulerAngles = transform.parent.localEulerAngles;

		camera = GetComponent<Camera>();
	}

	void LateUpdate()
    {
		if (followTarget == null || characterTransform == null)
			return;

		// Pitch and yaw
		if (allowInput && Input.GetMouseButton(1))
		{
			parentLocalEulerAngles.x = Mathf.Clamp(parentLocalEulerAngles.x - Input.GetAxisRaw("Mouse Y") * pitchSpeed, pitchMin, pitchMax);
			parentLocalEulerAngles.y += Input.GetAxisRaw("Mouse X") * yawSpeed;
		}
		else
		{
			parentLocalEulerAngles.y = Mathf.LerpAngle(parentLocalEulerAngles.y, characterTransform.localEulerAngles.y, Time.deltaTime * resetYawSpeed);
		}

		while (parentLocalEulerAngles.y > 180)
			parentLocalEulerAngles.y -= 360;

		transform.parent.localEulerAngles = parentLocalEulerAngles;

		Cursor.lockState = !Input.GetMouseButton(1) ? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.visible = !Input.GetMouseButton(1);

		// Zoom and collision
		transform.parent.position = followTarget.position;

		if (allowInput)
			cameraLocalPosition.z = Mathf.Clamp(cameraLocalPosition.z + Input.mouseScrollDelta.y * zoomSpeed, zoomMinZ, zoomMaxZ);

		if (Physics.SphereCast(followTarget.position, camera.nearClipPlane * 0.5f, transform.parent.TransformVector(cameraLocalPosition), out RaycastHit hit, cameraLocalPosition.magnitude, collisionLayerMask, QueryTriggerInteraction.Ignore))
		{
			transform.position = transform.parent.position + transform.parent.TransformVector(cameraLocalPosition).normalized * hit.distance;
		}
		else
		{
			transform.localPosition = cameraLocalPosition;
		}
	}

	public void SetAllowInput(bool value)
	{
		allowInput = value;
	}

	public void SetFollowTarget(Transform target)
	{
		followTarget = target;
	}
}
