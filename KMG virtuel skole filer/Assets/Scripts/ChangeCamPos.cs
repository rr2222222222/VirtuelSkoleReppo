using UnityEngine;

public class ChangeCamPos : MonoBehaviour, IInteractable
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform camDesiredPosition;

    [SerializeField] private bool canLookWhile = false;

    private Vector3 camOriginalPosition, camOriginalRotation;
    private bool activated = false;

    public void Interact()
    {
        if (!gameObject.CompareTag("Interactable"))
            return;

        if (!activated)
            Activate();
    }

    private void Update()
    {
        if (activated)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, camDesiredPosition.position, Time.deltaTime);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, camDesiredPosition.rotation, Time.deltaTime);
        }
        

        if (Input.GetKeyDown(KeyCode.Escape) && activated)
        {
            activated = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovementFPS>().enabled = true;
            cam.gameObject.GetComponent<MoveCamera>().enabled = true;

            cam.transform.position = camOriginalPosition;
            cam.transform.eulerAngles = camOriginalRotation;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
            Activate();
    }

    private void Activate()
    {
        if (!canLookWhile)
            cam.gameObject.GetComponent<MoveCamera>().enabled = false;


        camOriginalPosition = cam.transform.position;
        camOriginalRotation = cam.transform.eulerAngles;
        
        activated = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMovementFPS>().enabled = false;
    }
}
