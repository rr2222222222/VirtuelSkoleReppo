using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementTPS : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 vel;

    [Header("Variables")]
    [SerializeField] private Transform cam;
    [Space(10)]

    [Header("Basic Movement")]
    [SerializeField] float speed = 6f;
    [SerializeField] float gravity = -20f;
    [SerializeField] float jump = 2.5f;
    [Space(10)]

    [Header("Ground Checks")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDist = .1f;
    [SerializeField] LayerMask groundLayer;
    private bool isGrounded;
    [Space(10)]

    [Header("Rotation")]
    [SerializeField] float smooth = .1f;
    private float smoothVel;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayer);
        if (isGrounded && vel.y < 0)
            vel.y = -2f;

        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(hori, 0f, vert).normalized;

        if (dir.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVel, smooth);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool j = Input.GetButtonDown("Jump");

        if (j && isGrounded)
            vel.y = Mathf.Sqrt(jump * -2f * gravity);

        vel.y += gravity * Time.deltaTime;
        controller.Move(vel * Time.deltaTime);
    }
}
