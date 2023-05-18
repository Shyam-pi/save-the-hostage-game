using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public float collectionRadius = 2f;
    public GameObject player;
    public GameObject hostage;
    private bool canCollect = false;
    private Collider currentCollectible = null;
    // Start is called before the first frame update
    public int numEnemies;

     private void Update()
    {
        numEnemies = CountObjectsWithTag("Enemy");
        Debug.Log("Number of enemies = " + numEnemies);
        if (numEnemies == 0 && canCollect && OVRInput.GetDown(OVRInput.Button.Two)) // Change "Fire1" to the button you want to use for finding the hostage
        {
            FoundHostage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hostage")) // Change "HealthKit" to the tag you assign to your health kit objects
        {
            canCollect = true;
            currentCollectible = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == currentCollectible)
        {
            canCollect = false;
            currentCollectible = null;
        }
    }

    private void FoundHostage()
    {
        // Add your health replenishment logic here
        Debug.Log("Hostage Found!");
        player.GetComponent<ControllerManagerLeft>().gameSuccess.SetActive(true);
        hostage.SetActive(false);
        // player.GetComponent<ControllerManagerLeft>().health += 20;

        // Destroy the health kit object
        // Destroy(currentCollectible.gameObject);
    }

    private int CountObjectsWithTag(string tag)
    {
        int num = 0;
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject GO in objects){
            if(!GO.GetComponent<Enemy>().isDead){
                num += 1;
            }
        }
        return num;
    }

     private void FixedUpdate()
    {
        // Check for nearby health kits in the collection radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, collectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Hostage")) // Change "HealthKit" to the tag you assign to your health kit objects
            {
                canCollect = true;
                currentCollectible = collider;
                return; // Only collect the nearest health kit
            }
        }

        // If no hostage is found in range, disable collection
        canCollect = false;
        currentCollectible = null;
    }
}
