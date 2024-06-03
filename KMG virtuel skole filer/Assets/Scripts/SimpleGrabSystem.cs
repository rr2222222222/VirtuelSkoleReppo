using UnityEngine;
/// <summary>
/// Simple example of Grabbing system.
/// </summary>
public class SimpleGrabSystem : MonoBehaviour
{
    public char[] keybind = new char[5];
    // Reference to the slot for holding picked item.
    [SerializeField]
    private Transform slot;
    // Reference to the currently held item.
    private PickableItem pickedItem;

    private void Update()
    {
        if (slot.transform.childCount == 1)
        {
            if (Input.GetKeyDown(keybind[0].ToString()))
            {
                Transform meme = slot.transform.GetChild(0);
                meme.parent = null;
                meme.GetComponent<Rigidbody>().isKinematic = false;
                meme.GetComponent<Rigidbody>().AddForce(0, 500f, 150f, ForceMode.Acceleration);

            }
            if (Input.GetKeyDown(keybind[1].ToString()))
            {
                Transform meme = slot.transform.GetChild(0);
                meme.parent = null;
                meme.GetComponent<Rigidbody>().isKinematic = false;
                meme.GetComponent<Rigidbody>().AddForce(0f, -100f, -100f, ForceMode.Acceleration);

            }
            if (Input.GetKeyDown(keybind[2].ToString()))
            {
                GameObject memet = GameObject.Find("Elvis Character");
                memet.GetComponent<Rigidbody>().AddForce(0f, 150f, 0f, ForceMode.Acceleration);
            }
        }
      
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name =="Basketball")
        {
            other.transform.parent = slot;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = slot.position;
            Debug.Log("Grabbed!");
        }
        
    }

}