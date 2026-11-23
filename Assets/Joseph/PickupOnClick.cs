using UnityEngine;

public class PickupOnClick : MonoBehaviour
{
    
    //if mouse is down, raycast forward. If it hits an object with a rigidbody, pick it up. If mouse is up, drop the object.
    [Header("Pickup Settings")]
    public float pickupRange = 5f;
    public Transform holdParent;
    public Camera cameraObject;

    private GameObject pickedUpObject;

    private bool inputMouseDown = false;
    private bool holdingObject = false;
    void Update()
    {
        getInput();
        
        if(inputMouseDown)
        {
            if (!holdingObject)
            {
                pickupObject();    
            }
            
        }
        else
        {
            if(holdingObject)
            {
                dropObject();
            }
        }
    }

    private void getInput()
    {
        inputMouseDown = Input.GetMouseButton(0);
    }
    private void pickupObject()
    {
        RaycastHit hit;
        if(Physics.Raycast(cameraObject.transform.position, cameraObject.transform.forward, out hit, pickupRange))
        {
            if(hit.rigidbody != null)
            {
                pickedUpObject = hit.collider.gameObject;
                pickedUpObject.transform.SetParent(holdParent);
                pickedUpObject.GetComponent<Rigidbody>().isKinematic = true;
                holdingObject = true;
            }
        }
    }

    private void dropObject()
    {
        pickedUpObject.transform.SetParent(null);//TODO: PRESERVE HEIRARCHY OF ORIGINAL OBJECT
        pickedUpObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedUpObject = null;
        holdingObject = false;
    }

}
