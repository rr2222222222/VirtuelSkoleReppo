using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBottomChecker : MonoBehaviour
{
    public GameObject CarBlock;
    public GameObject teleportTarget;
    public GameObject PlayerTeleportTarget;
    public GameObject Car;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {



            
            CarBlock.SetActive(true);
            Car.transform.position = teleportTarget.transform.position;
            other.transform.position = PlayerTeleportTarget.transform.position;


        }
    }
}
