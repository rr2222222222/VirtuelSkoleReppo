using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    public GameObject basketUI;
    public SimpleGrabSystem grabsystem;
    public Ball ball;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            basketUI.SetActive(true);
            grabsystem.enabled = true;
            ball.enabled = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player")
        {
            basketUI.SetActive(false);
            grabsystem.enabled = false;
            ball.enabled = false;
        }
        
    }
}
