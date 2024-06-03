using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioClipHandler : MonoBehaviour
{
    
    public AudioSource source;
    public AudioClip clip;

    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {



            source.PlayOneShot(clip);
            




        }
    }
}
