using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement1 : MonoBehaviour
{
    private Vector3 startingPos = new Vector3(-96.5899963f, -22.7066364f, 93.4599991f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * -0.02f);
        Debug.Log(transform.position);

        if (transform.position.x <= -293)
        {
            transform.position = startingPos;


        }


    }
}
