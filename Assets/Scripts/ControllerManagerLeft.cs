using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControllerManagerLeft : MonoBehaviour
{
    private GameObject selectedObject;
    private Rigidbody HitObject;
    public float moveForce;
    public GameObject bullet;
    public Transform gun;
    private float fireRate = 200f;
    private float nextTimeToFire = 0.0f;
    private int bulletCount;
    private TextMeshProUGUI timerText;
    public GameObject timerTextGameObject; 
    private float timeRemaining = 60;
    public GameObject timeUp;
    public GameObject leftGunScore;
    private TextMeshProUGUI leftGunScoreText;
    private float shootingRange = 100f;
    private Vector3 endPosition;
    private Enemy enemy;
    int layerMask = 1 << 8;
    private bool hitOnce;
    public GameObject dirt;
    public GameObject blood;

    void Start()
    {
        Vector3[] startLinePositions = new Vector3[2] {Vector3.zero, Vector3.zero};
        bulletCount = 0;
        timerText = timerTextGameObject.GetComponent<TextMeshProUGUI>();
        timeUp.SetActive(false);
        leftGunScoreText = leftGunScore.GetComponent<TextMeshProUGUI>();
        leftGunScoreText.rectTransform.position = gun.position + Vector3.back * 0.12f + Vector3.up * 0.05f;
        SetCountText(timeRemaining);
        layerMask = ~layerMask;
        hitOnce = false;

    }

    void Update()
    {

        if (timeRemaining > 0)
        {
            
            float triggerVal = GetTriggerPress();
            if (triggerVal == 1 && Time.time >= nextTimeToFire)
            {
                rayCast();
                nextTimeToFire = Time.time + 1f / fireRate; 
                
            } else if (triggerVal == 0)
            {
                hitOnce = false;

            }
            
            timeRemaining -= Time.deltaTime;
            leftGunScoreText.rectTransform.position = gun.position + Vector3.back * 0.12f + Vector3.up * 0.05f;
            SetCountText(timeRemaining);
        } else
        {
            timerTextGameObject.SetActive(false);
            timeUp.SetActive(true);

        }
        
    }
   
    void SetCountText(float timeToDisplay)
    {
        timeToDisplay += 1; 
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        leftGunScoreText.text = bulletCount.ToString();


    }

    private void ApplyForce(Rigidbody body, Vector3 endPosition)
    {
        Vector3 direction = endPosition - transform.position;
        float distance = direction.magnitude;
        float force = 500f;
        float forceMagnitude = force * distance;
        Vector3 forceVector = direction.normalized * forceMagnitude;
        body.AddForce(forceVector, ForceMode.Force);
    }

    private void rayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))

        {
            selectedObject = hit.collider.gameObject;
            endPosition = hit.point;
            if (!hitOnce)
            {
                hitOnce = true;
                bulletCount = bulletCount + 1;
            }
            if (selectedObject.GetComponent<Rigidbody>())
            {
                // GameObject bulletObject = (GameObject)Instantiate(bullet, gun.localPosition, gun.rotation);
                // bulletObject.GetComponent<ProjectileController>().hitpoint = hit.point; 
                
                HitObject = selectedObject.GetComponent<Rigidbody>();
                enemy = hit.transform.GetComponent<Enemy>();
                ApplyForce(HitObject, endPosition);

                if (enemy != null)
                {
                    enemy.shot();
                }

            }
            Collider col = selectedObject.GetComponent<Collider>(); 
            if (col.gameObject.CompareTag("Enemy"))
            {
                GameObject newBlood = Instantiate(blood, col.transform.position, this.transform.rotation);
                newBlood.transform.parent = col.transform;
            }
            else
            {
                Instantiate(dirt, col.transform.position, this.transform.rotation);
            }
        }
        
    }

    float GetTriggerPress() 
    {
        return OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

    }

}

