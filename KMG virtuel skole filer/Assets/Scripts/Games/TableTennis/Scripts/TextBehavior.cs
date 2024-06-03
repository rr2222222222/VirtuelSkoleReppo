using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehavior : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        Vector3 v = Player.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(Player.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
