using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class NotificationQuickView : MonoBehaviour
{
    public SteamVR_Action_Boolean grabPinchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    public SteamVR_Input_Sources handType;
    public bool handInNotification;
    public NotificationDashboard script;
    public GameObject messageBubble;
    public string noticeName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabPinchAction.GetStateDown(handType))
        {
            if (handInNotification)
            {
                noticeName = gameObject.name;
                messageBubble.SetActive(true);
            } 
        }

        if (grabPinchAction.GetStateUp(handType))
        {
            if (messageBubble.activeSelf)
            {
                messageBubble.SetActive(false);
                NotificationDashboard script = GameObject.Find("NotificationOverview").GetComponent<NotificationDashboard>();
                script.CreateDetailedNotification(gameObject.name);
                Debug.Log("Creating Detailed Notification...");
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        handInNotification = true;
    }

    void OnTriggerExit(Collider collider)
    {
        handInNotification = false;
    }
}
