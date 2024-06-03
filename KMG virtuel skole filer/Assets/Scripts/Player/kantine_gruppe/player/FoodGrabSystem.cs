using UnityEngine;
using UnityEngine.UI;

public class FoodGrabSystem : MonoBehaviour
{

    float madspildTid = 0f;
    float wowTid = 0f;

    public Text madspild;
    public penge lommepenge;
    public Text Wow;

    // Reference to the character camera.
    [SerializeField]
    private Camera characterCamera;

    // Reference to the slot for holding picked item.
    [SerializeField]
    private Transform slot;

    // Reference to the currently held item.
    private PickableItem pickedItem;
    public Spawn_mad SpawnHotDog;

    private void Start()
    {
        Wow.enabled = false;
    }

    /// <summary>
    /// Method called very frame.
    /// </summary>
    private void Update()
    {
        // Execute logic only on button pressed
        if (Input.GetButtonDown("Fire1"))
        {
            // Check if player picked some item already
            if (pickedItem)
            {
                // If yes, drop picked item
                DropItem(pickedItem);
            }
            else
            {
                // If no, try to pick item in front of the player
                // Create ray from center of the screen
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit hit;
                // Shot ray to find object to pick
                if (Physics.Raycast(ray, out hit, 3f))
                {
                    // Check if object is pickable
                    var pickable = hit.transform.GetComponent<PickableItem>();
                    var pickedItem = hit.collider.gameObject.name;

                    // If object has PickableItem class
                    if (pickable && lommepenge.lommepenge >= pickable.madpris)
                    {
                        if (pickable.kobt == true)
                        {
                            PickItem(pickable);


                        }

                        else if (pickable.kobt == false && lommepenge.lommepenge >= pickable.madpris)
                        {
                            PickItem(pickable);
                            lommepenge.lommepenge = lommepenge.lommepenge - pickable.madpris;
                            pickable.kobt = true;
                            string foodName = pickable.name;
                            float foodpris = pickable.GetComponent<PickableItem>().madpris;
                            SpawnHotDog.SpawnHotDog(foodName, foodpris);

                        }
                    }
                }
            }
        }

        if (Input.GetKey(KeyCode.Space) && slot.transform.childCount == 1)
        {
            if (slot.transform.GetChild(0).tag == "Mad")
            {
                Destroy(pickedItem.gameObject);
            }
            if (slot.transform.GetChild(0).tag == "Wow")
            {
                Wow.enabled = true;
                wowTid = 300f;
                Destroy(pickedItem.gameObject);
            }

        }
      

        if (madspildTid == 0f)
        {
            madspild.enabled = false;
        }
        if (wowTid == 0f)
        {
            Wow.enabled = false;
        }

        madspildTid = madspildTid - 1f;
        wowTid = wowTid - 1f;

    }

    /// Method for picking up item.
    private void PickItem(PickableItem item)
    {
        // Assign reference
        pickedItem = item;

        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        // Set Slot as a parent
        item.transform.SetParent(slot);

        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;

    }

    /// Method for dropping item.
    private void DropItem(PickableItem item)
    {
        if (slot.transform.GetChild(0).tag == "Mad")
        {
            madspild.enabled = true;
            madspildTid = 900f;
        }
        // Remove reference
        pickedItem = null;

        // Remove parent
        item.transform.SetParent(null);

        // Enable rigidbody
        item.Rb.isKinematic = false;

        // Add force to throw item a little bit
        item.Rb.AddForce(item.transform.forward * 500);


    }

}
