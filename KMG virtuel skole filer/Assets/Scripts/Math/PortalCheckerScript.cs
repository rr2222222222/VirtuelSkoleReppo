using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCheckerScript : MonoBehaviour
{
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Portal3;
    public GameObject PortalWIN;

    void Update()
    {
        if(Portal1.activeSelf == false && Portal2.activeSelf == false && Portal3.activeSelf == false)
        {
            PortalWIN.SetActive(true);
        }
    }

}
