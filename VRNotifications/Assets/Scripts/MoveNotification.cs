using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MoveNotification : MonoBehaviour
{
    public bool isInTrigger;
    public bool isInHand;
    public GameObject rightHand;
    public GameObject messageBubble;
    public SteamVR_Action_Boolean grabPinchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    public SteamVR_Input_Sources handType;

    void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        isInTrigger = false;
        isInHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabPinchAction.GetStateDown(handType))
        {
            if (isInTrigger)
            {
                messageBubble.SetActive(true);
                gameObject.SetActive(false);
                isInHand = true;
            }
        }

        if (grabPinchAction.GetStateUp(handType))
        {
            if (isInHand)
            {
                messageBubble.SetActive(false);
                isInHand = false;
                gameObject.transform.position = rightHand.transform.position;
            }
        }
    }
}
