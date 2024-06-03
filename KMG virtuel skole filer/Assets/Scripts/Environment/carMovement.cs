using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carMovement : MonoBehaviour
{
    public Vector3 startingPos;
    public float dist;
    public float maxDist;
    public float speed;
    public GameObject deathPanel;
    public Vector3 player;
    //= new Vector3(-289.100006f, -22.7066364f, 95.6999969f)

    // Start is called before the first frame update
    void Start()
    {
        startingPos = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, startingPos);
        transform.Translate(Vector3.back * speed);

        if(dist >=maxDist )
        {
            transform.position = startingPos;
            
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = player;
            deathPanel.SetActive(true);
            StartCoroutine(ExampleCoroutine());

        }
    }
    IEnumerator ExampleCoroutine()
    {


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        deathPanel.SetActive(false);

    }
}
