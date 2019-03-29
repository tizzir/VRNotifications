using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShowNotice : MonoBehaviour
{
    public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    public SteamVR_Input_Sources handType;
    public GameObject notificationDashboard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabGripAction.GetStateDown(handType))
        {
            notificationDashboard.SetActive(!notificationDashboard.activeSelf);
        }
    }
}
