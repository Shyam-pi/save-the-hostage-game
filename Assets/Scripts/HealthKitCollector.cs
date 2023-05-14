using UnityEngine;

public class HealthKitCollector : MonoBehaviour
{
    public float collectionRadius = 2f;
    public GameObject player;
    private bool canCollect = false;
    private Collider currentCollectible = null;

    private void Update()
    {
        if (canCollect && OVRInput.GetDown(OVRInput.Button.Two)) // Change "Fire1" to the button you want to use for collecting the health kit
        {
            CollectHealthKit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthKit")) // Change "HealthKit" to the tag you assign to your health kit objects
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

    private void CollectHealthKit()
    {
        // Add your health replenishment logic here
        Debug.Log("Health kit collected!");
        player.GetComponent<ControllerManagerLeft>().health += 20;

        // Destroy the health kit object
        Destroy(currentCollectible.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Display the collection sphere in the Scene view for easier visualization
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, collectionRadius);
    }

    private void FixedUpdate()
    {
        // Check for nearby health kits in the collection radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, collectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("HealthKit")) // Change "HealthKit" to the tag you assign to your health kit objects
            {
                canCollect = true;
                currentCollectible = collider;
                return; // Only collect the nearest health kit
            }
        }

        // If no health kit is found in range, disable collection
        canCollect = false;
        currentCollectible = null;
    }
}
