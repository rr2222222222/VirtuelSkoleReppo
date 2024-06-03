using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBlockChecker : MonoBehaviour
{

    public GameObject CarBlock;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {




            CarBlock.SetActive(false);



        }
    }


}


