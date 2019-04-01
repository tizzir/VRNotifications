using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using Valve.VR.InteractionSystem;

public class NotificationDashboard : MonoBehaviour
{
    public struct Notification
    {
        public Boolean canReply;                // Notification from a person, or website
        public string name;                     // Name to appear in notification (Sophie, Facebook, LinkedIn News)
        public string noticeMessage;           // Their message to appear in notification 
    }

    public GameObject notificationPrefab;
    public List<Notification> notificationList;
    public bool noNotifications;

    public GameObject notice0;
    public GameObject notice1;
    public GameObject notice2;
    public GameObject noNotificationNotice;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject hmd;

    public const int NumberOfNoticesShown = 3;
    public const int MaxCharacters = 50;

    // Start is called before the first frame update
    void Start()
    {
        notificationList = new List<Notification>();
        noNotifications = true;

        Notification newNotice;
        newNotice.canReply = false;
        newNotice.name = "Instagram";
        newNotice.noticeMessage = "Matt liked your photo.";

        AddSpecifiedElement(newNotice);
    }

    // Update is called once per frame
    void Update()
    {
        TriggerNotification();

        if (notificationList.Count > 0)
        {
            noNotificationNotice.SetActive(false);
            // Display first 3 notifications on overview
            if (notificationList.Count >= 1)
            {
                notice0.SetActive(true);
                notice0.transform.Find("NameLength0").transform.Find("name0").GetComponent<TextMesh>().text = notificationList[0].name;
                string value = notificationList[0].noticeMessage;
                string tempString = value.Length <= MaxCharacters ? value : value.Substring(0, MaxCharacters) + "...";
                notice0.transform.Find("NoticeMessageLength0").transform.Find("noticeMessage0").GetComponent<TextMesh>().text = tempString;
            }

            if (notificationList.Count >= 2)
            {
                notice1.SetActive(true);
                notice1.transform.Find("NameLength1").transform.Find("name1").GetComponent<TextMesh>().text = notificationList[1].name;
                string value = notificationList[1].noticeMessage;
                string tempString = value.Length <= MaxCharacters ? value : value.Substring(0, MaxCharacters) + "...";
                notice1.transform.Find("NoticeMessageLength1").transform.Find("noticeMessage1").GetComponent<TextMesh>().text = tempString;
            }
            else
            {
                notice1.SetActive(false);
            }

            if (notificationList.Count >= 3)
            {
                notice2.SetActive(true);
                notice2.transform.Find("NameLength2").transform.Find("name2").GetComponent<TextMesh>().text = notificationList[2].name;
                string value = notificationList[2].noticeMessage;
                string tempString = value.Length <= MaxCharacters ? value : value.Substring(0, MaxCharacters) + "...";
                notice2.transform.Find("NoticeMessageLength2").transform.Find("name2").GetComponent<TextMesh>().text = tempString;
            }
            else
            {
                notice2.SetActive(false);
            }

        }
        else
        {
            noNotificationNotice.SetActive(true);
            notice0.SetActive(false);
            notice1.SetActive(false);
            notice2.SetActive(false);
        }
    }

    // Removes notification from notification gameobject and notification list
    void RemoveSpecifiedElement(Notification notification)
    {
        notificationList.Remove(notification);
    }

    // Adds notification from notification gameobject and notification list
    void AddSpecifiedElement(Notification notification)
    {
        notificationList.Insert(0, notification);
    }

    // Creates the detailed notification
    public void CreateDetailedNotification(string noticeNumber)
    {
        int res = Int32.Parse(Regex.Match(noticeNumber, @"\d+").Value);
        GenerateNoticeObject(notificationList[res]);

        Debug.Log("Created Notification!");

        // Remove specified element in list
        RemoveSpecifiedElement(notificationList[res]);
        Debug.Log("Deleted Notification!");
    }

    // Creates a new notification game object
    void GenerateNoticeObject(Notification notification)
    {
        GameObject notice = Instantiate(notificationPrefab, gameObject.transform.position, Quaternion.identity);
        notice.transform.Find("NotificationView").transform.Find("Reply").GetComponent<Reply>().setLeftHand(leftHand);
        notice.transform.Find("NotificationView").transform.Find("Reply").GetComponent<Reply>().setHMD(hmd);
        notice.transform.position = rightHand.transform.position;
        notice.transform.LookAt(hmd.transform);
        notice.transform.Rotate(0, -90, -20, Space.Self);
        notice.transform.Find("NotificationView").transform.Find("NameLength").transform.Find("name").GetComponent<TextMesh>().text = notification.name;
        notice.transform.Find("NotificationView").transform.Find("NoticeMessageLength").transform.Find("noticeMessage").GetComponent<TextMesh>().text = notification.noticeMessage;


    }

    // Adds a new notification to the list depending on which key is pressed
    void TriggerNotification()
    {
        Hand hand = gameObject.GetComponent<Hand>();

        // Instagram
        if (Input.GetKeyDown("i"))
        {
            Notification newNotice;
            newNotice.canReply = true;
            newNotice.name = "Instagram";
            newNotice.noticeMessage = "Kevin sent you a direct message.";

            AddSpecifiedElement(newNotice);

            if (hand != null)
            {
                hand.TriggerHapticPulse(0.5f, 20f, 1000f);
            }
        }
        // Facebook
        else if (Input.GetKeyDown("f"))
        {
            Notification newNotice;
            newNotice.canReply = true;
            newNotice.name = "Facebook";
            newNotice.noticeMessage = "Wish Mary Jo a Happy Birthday!";

            AddSpecifiedElement(newNotice);

            if (hand != null)
            {
                hand.TriggerHapticPulse(0.5f, 20f, 1000f);
            }
        }
        // LinkedIn
        else if (Input.GetKeyDown("l"))
        {
            Notification newNotice;
            newNotice.canReply = false;
            newNotice.name = "LinkedIn";
            newNotice.noticeMessage = "Mark Zukerberg wants to connect.";

            AddSpecifiedElement(newNotice);

            if (hand != null)
            {
                hand.TriggerHapticPulse(0.5f, 20f, 1000f);
            }
        }
        // News
        else if (Input.GetKeyDown("n"))
        {
            Notification newNotice;
            newNotice.canReply = false;
            newNotice.name = "News";
            newNotice.noticeMessage = "Brexit is happening.";

            AddSpecifiedElement(newNotice);

            if (hand != null)
            {
                hand.TriggerHapticPulse(0.5f, 20f, 1000f);
            }
        }
        // Text message
        else if (Input.GetKeyDown("t"))
        {
            Notification newNotice;
            newNotice.canReply = true;
            newNotice.name = "Mom";
            newNotice.noticeMessage = "You're the best!";

            AddSpecifiedElement(newNotice);

            if (hand != null)
            {
                hand.TriggerHapticPulse(0.5f, 20f, 1000f);
            }
        }
    }
}