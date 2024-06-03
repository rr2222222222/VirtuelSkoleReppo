using UnityEngine;

public class GrapplingGun : MonoBehaviour {
    public string grapplekey = "e";
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    public float maxDistance = 100f;
    private SpringJoint joint;

    void Update()
    {
        if (keydown(grapplekey))
        {
            StartGrapple();
        }
        else if (keyup(grapplekey))
        {
            StopGrapple();
        }
    }



    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.001f;
            joint.minDistance = distanceFromPoint * 0.00025f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple() {
        Destroy(joint);
    }



    public bool IsGrappling() {
        return joint != null;
    }
    private bool keydown(string test)
    {
        return Input.GetKeyDown(test);
    }
    private bool keyup(string test)
    {
        return Input.GetKeyUp(test);
    }
    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}
