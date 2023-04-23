using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public bool isDead = false;
    private TextMeshProUGUI healthText;
    public GameObject healthGO;
    void Start()
    {
        health = 100;
        isDead = false;
        healthText = healthGO.GetComponent<TextMeshProUGUI>();
        healthText.rectTransform.position = transform.position + new Vector3(0, 0, 0);
        healthText.text = health.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // Destroy(gameObject, 1.5f);
            isDead = true;
        }
        healthText.text = health.ToString();
    }

    // public void shot()
    // {
    //     Destroy(gameObject, 1.5f);

    // }


}
