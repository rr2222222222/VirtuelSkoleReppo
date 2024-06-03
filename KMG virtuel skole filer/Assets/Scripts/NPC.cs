using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private bool triggering;
    public GameObject panel;
    public GameObject interactTip;
    public Text textBox;
    public string dialogue;
    public Text nameBox;
    public GameObject interactNameObj;
    public Text interactName;

    void Update()
    {
        if(triggering)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                panel.SetActive(true);
                interactTip.SetActive(false);
                interactNameObj.SetActive(false);
                triggering = false;
                textBox.text = dialogue;
                nameBox.text = gameObject.name;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = true;
            interactTip.SetActive(true);
            interactName.text = gameObject.name;
            interactNameObj.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            panel.SetActive(false);
            interactTip.SetActive(false);
            interactNameObj.SetActive(false);
        }
    }
}