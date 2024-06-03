using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapScript : MonoBehaviour
{
    public RawImage map;
    public GameObject UIPopUp;
    public GameObject closeMap;
    public void Awake()
    {
        UIPopUp.SetActive(false);
        closeMap.SetActive(false);
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            UIPopUp.SetActive(true);
        }
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            map.enabled = true;
            UIPopUp.SetActive(false);
            closeMap.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            map.enabled = true;
            UIPopUp.SetActive(false);
            closeMap.SetActive(true);
        }
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.V))
        {
            map.enabled = false;
            closeMap.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            map.enabled = false;
        }
        UIPopUp.SetActive(false);
        closeMap.SetActive(false);
    }
}
