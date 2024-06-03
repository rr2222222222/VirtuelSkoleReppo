using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPickup : MonoBehaviour
{
    public BookPickupManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.currentBookCounter++;
            gameObject.SetActive(false);
        }
    }
}
