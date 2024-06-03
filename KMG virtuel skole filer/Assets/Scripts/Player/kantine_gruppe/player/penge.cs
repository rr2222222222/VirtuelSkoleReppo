using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class penge : MonoBehaviour
{


    public Text pengetext;
    float pengetid = 10f;
    float passiveMoney = 1;

    public float lommepenge = 90;


    float t = 0f;
    float threshold = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t>= threshold)
        {
            t = 0;
            lommepenge += passiveMoney;
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            lommepenge = lommepenge + 1;
        }
        pengetid = pengetid - 1;



        if (pengetid < 0) {
            lommepenge = lommepenge + 10;
            pengetid = 6000f;
        }

        pengetext.text = "Lommepenge: " + lommepenge.ToString();
    }
   
}
