using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 50;
    public bool isDead = false;
    // private TextMeshProUGUI healthText;
    // public GameObject healthGO;
    public GameObject healthBar;
<<<<<<< Updated upstream
=======
    public bool isHit;
    private float delay = 0.433f;
    private float time = 0f;

>>>>>>> Stashed changes
    void Start()
    {
        health = 50;
        isDead = false;
        // healthText = healthGO.GetComponent<TextMeshProUGUI>();
        // healthText.rectTransform.position = transform.position + transform.forward * 0.5f + transform.up * 2;
        // healthText.text = health.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            // healthText.rectTransform.position = transform.position + transform.forward * 0.5f + transform.up * 2;
            if (health <= 0)
            {
                // Destroy(gameObject, 1.5f);
                isDead = true;
<<<<<<< Updated upstream
=======
                // this.gameObject.SetActive(false);
>>>>>>> Stashed changes
                //Destroy(soldier.GetComponent<EnemyAnimationStateController>());

            }
            // healthText.text = health.ToString();

        } else
        {
            // healthGO.SetActive(false);
            healthBar.SetActive(false);
        } 
<<<<<<< Updated upstream
=======
        //make the enemy upright all the time
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
>>>>>>> Stashed changes
    }

    // public void shot()
    // {
    //     Destroy(gameObject, 1.5f);

    // }


}
