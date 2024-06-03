using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPickupManager : MonoBehaviour
{
    public int bookCounter;
    public int currentBookCounter;
    public Text textfield;
    public GameObject prefab;
    public Transform parent;

    public GameObject[] Books;
    public Transform[] BookPos;

    void Start()
    {
        int i = parent.childCount;
        BookPos = new Transform[i];
        for (int j = 0; j < i; j++)
        {
            BookPos[j] = parent.GetChild(j);
        }
        Books = new GameObject[i];
        //books = GameObject.FindGameObjectsWithTag("Book");
        bookCounter = i;
        currentBookCounter = 0;

        for (int j = 0; j < bookCounter; j++)
        {
            GameObject instantiatedObject = Instantiate(prefab, BookPos[j].position, Quaternion.identity);
            instantiatedObject.name = j.ToString();
            instantiatedObject.GetComponent<BookPickup>().manager = this;
            //instantiatedObject.layer = 7;
            Books[j] = instantiatedObject;
        }
    }

    void Update()
    {
        textfield.text = currentBookCounter.ToString() + "/" + bookCounter.ToString() + " Books";
    }
}
