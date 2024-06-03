using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSearcher : MonoBehaviour
{
    [SerializeField] bool run;

    void Update()
    {
        if(!run) return;

        run = false;
        Debug.Log(FindObjectsOfType<WindZone>().Length);
    }
}
