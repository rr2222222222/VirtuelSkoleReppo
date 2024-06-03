using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public GameObject resetPos;

    private int tableHits1 = 0;
    private int tableHits2 = 0;

    private int playerPoints = 0;
    private int npcPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetPosistion()
    {
        transform.position = resetPos.transform.position;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.AddForce(Random.Range(1, 50), -30, 120);
        tableHits1 = 0;
        tableHits2 = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name) {
            case "Collider1":
                ResetPosistion();
                playerPoints++;
                break;

            case "Collider2":
                ResetPosistion();
                npcPoints++;
                break;

            case "TableCollider1":
                tableHits1++;
                npcPoints++;
                break;

            case "TableCollider2":
                tableHits2++;
                playerPoints++;
                break;
        } 
            
        if(tableHits1 > 1 || tableHits2 > 1)
        {
            ResetPosistion();
        }
        
    }
}
