using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class ShowNotice : MonoBehaviour
    {
        public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
        public SteamVR_Input_Sources handType;
        public GameObject notificationDashboard;
        
        public GameObject leftHand;
        public GameObject messageBall;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            /*if(grabGripAction.GetStateDown(handType))
            {
                notificationDashboard.SetActive(!notificationDashboard.activeSelf);
                Hand hand = gameObject.GetComponent<Hand>();
                if (hand != null)
                { 
                    Debug.Log("Herewtfgwe");
                    hand.TriggerHapticPulse(0.5f, 20f, 1000f);

                    //SteamVR_Controller.Input( (int)trackedObject.index ).TriggerHapticPulse( (ushort)pulse );
		        } else {
		            Debug.Log("Hellooooo");
		        }
            }*/
            RaycastHit hit;
            Debug.DrawRay(leftHand.transform.position, leftHand.transform.forward, Color.green);
            if (Physics.Raycast(leftHand.transform.position, leftHand.transform.forward, out hit, Mathf.Infinity) || messageBall.activeSelf) {
                if (messageBall.activeSelf || hit.collider.gameObject.name == "gestureTest") {
                    notificationDashboard.SetActive(true);
                } else {
                    notificationDashboard.SetActive(false);
                }
            } else {
                notificationDashboard.SetActive(false);
            }
        }
    }
}
