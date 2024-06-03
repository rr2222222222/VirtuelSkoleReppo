using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject1PortalTrigger : MonoBehaviour
{
    public GameObject teleportTarget;
    public GameObject Subject1Portal;

    void OnTriggerEnter(Collider other)
    {



        if (other.tag == "Player")
        {




            other.transform.position = teleportTarget.transform.position;



        }
        Subject1Portal.SetActive(false);
    }
}
