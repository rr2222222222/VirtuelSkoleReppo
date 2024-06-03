using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipStopper : MonoBehaviour
{

    public AudioSource source;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {



            source.Stop();





        }
    }
}
