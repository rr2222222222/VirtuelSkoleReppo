using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTriggerButDestroy : MonoBehaviour
{
    public GameObject teleportTarget;
    public GameObject Portal;


    void OnTriggerEnter(Collider other)
    {



        if (other.tag == "Player")
        {




            other.transform.position = teleportTarget.transform.position;
            Portal.SetActive(false);


        }
    }
}
