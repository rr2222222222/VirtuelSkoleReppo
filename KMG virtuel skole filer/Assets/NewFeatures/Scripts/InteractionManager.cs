using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager interactionManager;

    [SerializeField] float dist = 3f;
    [SerializeField] private Camera cam;

    private GameObject selection;

    private void Awake()
    {
        if (interactionManager != null)
            Destroy(gameObject);
        else
            interactionManager = this;
    }

    private void Update()
    {
        HighlightCheck();

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * dist);

        if (Input.GetKeyDown(KeyCode.E) && selection != null)
            if (selection.CompareTag("Interactable"))
                selection.GetComponent<IInteractable>().Interact();
    }

    private void HighlightCheck()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, dist))
        {
            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                selection = hit.collider.gameObject;

                GameObject[] outlineToDisable = GameObject.FindGameObjectsWithTag("Interactable");

                for (int i = 0; i < outlineToDisable.Length; i++)
                    if (outlineToDisable[i] != selection && outlineToDisable[i].GetComponent<Outline>())
                        outlineToDisable[i].GetComponent<Outline>().enabled = false;

                selection.GetComponent<Outline>().enabled = true;
            }
            else if (selection != null)
            {
                selection.GetComponent<Outline>().enabled = false;
                selection = null;
            }
        }
        else
            if (selection != null)
        {
            selection.GetComponent<Outline>().enabled = false;
            selection = null;
        }
    }
}
