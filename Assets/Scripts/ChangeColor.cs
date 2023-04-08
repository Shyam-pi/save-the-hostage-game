using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeColor : MonoBehaviour
{
    public Material materialHit;
    public Material materialDefault;
    public bool isHit = false;
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
       mesh = GetComponent<MeshRenderer>();
       mesh.material = materialDefault;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            mesh.material = materialHit;

        }
        else
        {
            mesh.material = materialDefault;
        }

        if (FindObjectOfType<ControllerManager>().targetHit == false) // & FindObjectOfType<ControllerManagerLeft>().targetHit == false
        {
            isHit = false;
        }
    }
}

