using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using OVR;
public class JoystrickLocomotion : MonoBehaviour
{
    public Rigidbody player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        var joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        float fixedY = player.position.y;

        player.position += (joystickAxis.y * transform.forward + joystickAxis.x * transform.right) * speed * Time.deltaTime;
        player.position = new Vector3(player.position.x, fixedY, player.position.z);
    }
}
