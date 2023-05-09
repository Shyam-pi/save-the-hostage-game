using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 hitpoint;
    public float playerHealth;
    public ControllerManagerLeft m_someOtherScriptOnAnotherGameObject;


    void Start()
    {
        Debug.Log("Projectile Added force");
        Vector3 direction = hitpoint - transform.position;
        float distance = direction.magnitude;
        float force = 1000f;
        float forceMagnitude = force * distance;
        Vector3 forceVector = direction.normalized * forceMagnitude;
        this.GetComponent<Rigidbody>().AddForce(forceVector);
        Destroy(this.gameObject, 0.1f);
       

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "OVRCameraRig")
        {
            m_someOtherScriptOnAnotherGameObject = GameObject.FindObjectOfType(typeof(ControllerManagerLeft)) as ControllerManagerLeft;
            m_someOtherScriptOnAnotherGameObject.playerHit();
            // GetComponent<ControllerManagerLeft>().playerHit();
        }
    }
}
