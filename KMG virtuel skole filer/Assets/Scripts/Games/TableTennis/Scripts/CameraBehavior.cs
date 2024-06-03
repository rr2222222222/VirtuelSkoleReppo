using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject newCam;
    public GameObject player;
    public GameObject bat;
    public GameObject text;
    public GameObject ball;

    void Update()
    {
        if(Vector3.Distance(player.transform.position, newCam.transform.position) < 1.85)
        {
            if(!text.activeSelf && !newCam.activeSelf)
            {
                text.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.E) && !newCam.activeSelf)
            {
                bat.SetActive(true);
                ball.SetActive(true);
                mainCam.SetActive(false);
                newCam.SetActive(true);
                player.SetActive(false);
                text.SetActive(false);
            } 
        } 
        else
        {
            if (text.activeSelf)
            {
                text.SetActive(false);
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape) && newCam.activeSelf)
        {
            bat.SetActive(false);
            ball.SetActive(false);
            mainCam.SetActive(true);
            newCam.SetActive(false);
            player.SetActive(true);
            text.SetActive(true);
        }
    }
}
 