using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager singleton;
    // Start is called before the first frame update
    void Start()
    {
        if(singleton && singleton != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            singleton = this;
        }
    }

    // Update is called once per frame
    public void TriggerVibration(AudioClip vibrationAudio, OVRInput.Controller controller)
    {   //Create a new clip from the audio file, amplify it and set it to the controller
        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio, 10);
        
        if (controller == OVRInput.Controller.LTouch)
        {
            //Trigger vibration on left controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controller == OVRInput.Controller.RTouch)
        {   //Trigger vibration on right controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
        else
        {
            Debug.Log("No controller found");
        }
    }
}
