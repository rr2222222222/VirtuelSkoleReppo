using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_mad : MonoBehaviour
{

    public Transform[] madPos;


    public GameObject[] madPrefab;



    public void SpawnHotDog(string name, float price)
    {
        for (int i = 0; i < madPrefab.Length; i++)
        {
            if (name == madPrefab[i].name)
            {
                GameObject bob = Instantiate(madPrefab[i], madPos[i].position, madPrefab[i].transform.rotation);
                bob.GetComponent<PickableItem>().madpris = price;
                bob.name = name;
            }
        }
        
        
    }
}
