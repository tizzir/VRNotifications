using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class NotificationTrigger : MonoBehaviour
    {
        public NotificationDashboard notificationDashboard;

        // Use this for initialization
        void Start()
        {  
            notificationDashboard = GameObject.Find("NotificationOverview").GetComponent<NotificationDashboard>();
        }

        // Update is called once per frame
        void Update()
        {
            TriggerNotification();
        }

        // Adds a new notification to the list depending on which key is pressed
        void TriggerNotification()
        {
            Hand hand = gameObject.GetComponent<Hand>(); //NEED TO GET HAND FOR REAL

            // Instagram
            if (Input.GetKeyDown("i"))
            {
                notificationDashboard.AddNotification(true, "Instagram", "Kevin sent you a Direct Message.");

                if (hand != null)
                {
                    hand.TriggerHapticPulse(0.5f, 20f, 1000f);
                }
            }
            // Facebook
            else if (Input.GetKeyDown("f"))
            {
                notificationDashboard.AddNotification(true, "Facebook", "Wish MJ a Happy Birthday!");

                if (hand != null)
                {
                    hand.TriggerHapticPulse(0.5f, 20f, 1000f);
                }
            }
            // LinkedIn
            else if (Input.GetKeyDown("l"))
            {
                notificationDashboard.AddNotification(false, "LinkedIn", "Elon Musk wants to connect.");

                if (hand != null)
                {
                    hand.TriggerHapticPulse(0.5f, 20f, 1000f);
                }
            }
            // News
            else if (Input.GetKeyDown("n"))
            {
                notificationDashboard.AddNotification(false, "CNN", "Brexit is happening!");

                if (hand != null)
                {
                    hand.TriggerHapticPulse(0.5f, 20f, 1000f);
                }
            }
            // Text message
            else if (Input.GetKeyDown("t"))
            {
                notificationDashboard.AddNotification(true, "Mom", "You're the best!");

                if (hand != null)
                {
                    hand.TriggerHapticPulse(0.5f, 20f, 1000f);
                }
            }
        }
   }
}
