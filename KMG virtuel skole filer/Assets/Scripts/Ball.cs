using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject spawnPoint;
    public GameObject scoreText;
    public GameObject Basketball;
    public SimpleGrabSystem newKeyBind;
    public float score = 0;
    public int counter;
    private Text text;
    public Text instructions;


    // Start is called before the first frame update
    void Start()
    {
        instructions.text = newKeyBind.keybind[0].ToString() + " - Throw ball \n" + newKeyBind.keybind[1].ToString() + " - Dribble \n" + newKeyBind.keybind[2].ToString() + " - Jump \n" + newKeyBind.keybind[3].ToString()+" - Spawn ball \n"+ newKeyBind.keybind[4].ToString() + " - Destroy ball \n";
    }

    // Update is called once per frame
    void Update()
    {
        text = scoreText.GetComponent<Text>();
        text.text = "Score: " + score.ToString();
        if (Input.GetKeyDown(newKeyBind.keybind[3].ToString()) && counter ==0)
        {
            Basketball = Instantiate(myPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Basketball.name = "Basketball";
            counter=1;
        }
        if (Input.GetKeyDown(newKeyBind.keybind[4].ToString()) && counter == 1) {
            Destroy(Basketball);
            counter = 0;
        }


    }
     
    private void OnTriggerEnter(Collider other)
    {
        score++;
        if (other.name == Basketball.name) {
            Destroy(Basketball);
            counter = 0;
        }

    }

}
