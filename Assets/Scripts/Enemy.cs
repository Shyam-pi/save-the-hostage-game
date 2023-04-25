using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 50;
    public bool isDead = false;
    private TextMeshProUGUI healthText;
    public GameObject healthGO;
    void Start()
    {
        health = 50;
        isDead = false;
        healthText = healthGO.GetComponent<TextMeshProUGUI>();
        healthText.rectTransform.position = transform.position + transform.forward * 0.5f + transform.up * 2;
        healthText.text = health.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        healthText.rectTransform.position = transform.position + transform.forward * 0.5f + transform.up * 2;
        if (health <= 0)
        {
            // Destroy(gameObject, 1.5f);
            isDead = true;
            //Destroy(soldier.GetComponent<EnemyAnimationStateController>());

        }
        healthText.text = health.ToString();
    }

    // public void shot()
    // {
    //     Destroy(gameObject, 1.5f);

    // }


}
