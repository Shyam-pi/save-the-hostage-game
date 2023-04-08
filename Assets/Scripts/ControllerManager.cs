using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    private bool buttonPress = OVRInput.GetDown(OVRInput.Button.One);
    private Vector3 position;
    private Vector3 endPosition;
    private  Vector3 pointingDirection;
    private bool isButtonPress;
    private float triggerPress;
    public GameObject selectedObject;
    public GameObject grabbedObject;
    public bool targetHit = false;
    public float lineMaxLength = 100f;
    public float lineWidth = 0.01f;
    private Rigidbody HitObject;
    

    void Start()
    {
        Vector3[] startLinePositions = new Vector3[2] {Vector3.zero, Vector3.zero};

    }

    void Update()
    {
        position = GetPosition();
        pointingDirection = GetPointingDir();
        isButtonPress = GetButtonPress();
        triggerPress = GetTriggerPress();
        endPosition = position + pointingDirection*lineMaxLength;

        if (triggerPress > 0)
        {

            rayCast(position, pointingDirection);
        }
        else 
        {
            targetHit = false;
        }

        // if (triggerPress > 0)
        // {
        //     GrabObject();
        // }


    }



    private void ApplyForce(Rigidbody body, Vector3 endPosition)
    {
        Vector3 direction = endPosition - transform.position;
        float distance = direction.magnitude;
        float force = 1f;
        float forceMagnitude = force * distance;
        Vector3 forceVector = direction.normalized * forceMagnitude;
        body.AddForce(forceVector);
    }


    private void rayCast(Vector3 position, Vector3 pointingDirection)
    {
        RaycastHit hit;
        Ray castedRay = new Ray(position, pointingDirection);

        if (Physics.Raycast(castedRay, out hit))
        {
            endPosition = hit.point;
            selectedObject = hit.collider.gameObject;
            if (selectedObject.GetComponent<Rigidbody>())
            {
                targetHit = true;
                HitObject  = selectedObject.GetComponent<Rigidbody>();
                ApplyForce(HitObject, endPosition);
            }
            else
            {
                targetHit = false;
            }
        }
        else
        {
            targetHit = false;
        }
    }

    // private void GrabObject()
    // {
    //     if (grabbedObject)
    //     {
    //         grabbedObject.transform.position = transform.position;
    //     }
    // }
    
    // private void OnTriggerEnter(Collider collided)
    // {
    //     if (collided.gameObject.GetComponent<GrabableObject>())
    //     {
    //         grabbedObject = collided.gameObject;
    //     }
    // }

    Vector3 GetPosition()
    {
        position = transform.position;
        return position;
    }

    Vector3 GetPointingDir()
    {
        pointingDirection = transform.forward;
        return pointingDirection;
    }

    bool GetButtonPress()
    {
        isButtonPress = OVRInput.Get(OVRInput.Button.One);
        return isButtonPress;
    } 

    float GetTriggerPress() 
    {
        triggerPress = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        return triggerPress;
    }
}

