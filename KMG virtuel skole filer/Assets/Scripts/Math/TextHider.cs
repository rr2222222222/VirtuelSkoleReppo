using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHider : MonoBehaviour
{

    public GameObject Text;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {




            Text.SetActive(false);



        }
    }

    
    
}
