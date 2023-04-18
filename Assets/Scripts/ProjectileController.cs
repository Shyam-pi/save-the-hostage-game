using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 1000;
    public Vector3 hitpoint;
    public GameObject dirt;
    public GameObject blood;
    public bool specialEffectEnabled; 

    void Start()
    {
        Debug.Log("Projectile Added force");
        Vector3 direction = hitpoint - transform.position;
        float distance = direction.magnitude;
        float force = 500f;
        float forceMagnitude = force * distance;
        Vector3 forceVector = direction.normalized * forceMagnitude;
        this.GetComponent<Rigidbody>().AddForce(forceVector);
        Destroy(this.gameObject, 0.1f);

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Shoot");
        if (specialEffectEnabled)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                GameObject newBlood = Instantiate(blood, this.transform.position, this.transform.rotation);
                newBlood.transform.parent = col.transform;
            }
            else
            {
                Instantiate(dirt, this.transform.position, this.transform.rotation);
            }

        }
        Destroy(this.gameObject);
    }
}
