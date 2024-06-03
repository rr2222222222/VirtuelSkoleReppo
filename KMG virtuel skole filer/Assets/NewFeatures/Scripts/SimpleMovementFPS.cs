using UnityEngine;

public class SimpleMovementFPS : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 vel;
    private bool isGrounded;

    [Header("Basic Movement")]
    [SerializeField] float speed = 6f;
    [SerializeField] float gravity = -20f;
    [SerializeField] float jump = 2.5f;
    [Space(10)]

    [Header("Ground Checks")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDist = .1f;
    [SerializeField] LayerMask groundLayer;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayer);
        if (isGrounded && vel.y < 0)
            vel.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool j = Input.GetButtonDown("Jump");

        if (j && isGrounded)
            vel.y = Mathf.Sqrt(jump * -2f * gravity);

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        vel.y += gravity * Time.deltaTime;
        controller.Move(vel * Time.deltaTime);
    }
}
