using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTennis : MonoBehaviour
{
    public GameObject ball;
    public GameObject gameCam;

    void Start()
    {
        ball.SetActive(true);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(0, 0, 65);
    }

    void Update()
    {
        if(gameCam.activeSelf)
        {
            Camera gameCameraComponent = gameCam.GetComponent<Camera>();

            Vector3 mousePosistion = Input.mousePosition;
            Vector3 worldpoint = gameCameraComponent.ScreenToWorldPoint(new Vector3(mousePosistion.x, mousePosistion.y, gameCameraComponent.nearClipPlane + 0.55f));

            transform.parent.position = worldpoint;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == ball)
        {
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

            ballRigidbody.AddForce(0, -30, -120);
        }
    }
}
