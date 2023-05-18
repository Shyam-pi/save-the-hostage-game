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
    // public LineRenderer lineRenderer;

    public GameObject player;

    void Start()
    {
        Debug.Log("Projectile Added force");
        Vector3 direction = hitpoint - transform.position;
        // Vector3 globalYAxis = Vector3.up;

        // // Rotate the vector along the global Y-axis
        // float angle = 30f;
        // Quaternion rotation = Quaternion.AngleAxis(angle, globalYAxis);
        // direction = rotation * direction;

        float distance = direction.magnitude;
        float force = 1000f;
        float forceMagnitude = force * distance;
        Vector3 forceVector = direction.normalized * forceMagnitude;
        this.GetComponent<Rigidbody>().AddForce(forceVector);
        Destroy(this.gameObject, 0.4f);
        // lineRenderer = GetComponent<LineRenderer>();
        // lineRenderer.enabled = true;
        // lineRenderer.SetPosition(0, transform.position);
        // lineRenderer.SetPosition(1, hitpoint);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "player")
        {
            m_someOtherScriptOnAnotherGameObject = GameObject.FindObjectOfType(typeof(ControllerManagerLeft)) as ControllerManagerLeft;
            m_someOtherScriptOnAnotherGameObject.playerHit();
            Debug.Log(m_someOtherScriptOnAnotherGameObject.health);
            // GetComponent<ControllerManagerLeft>().playerHit();
        }
    }
}
