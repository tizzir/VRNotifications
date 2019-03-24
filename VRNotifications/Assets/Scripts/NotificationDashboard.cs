using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class NotificationDashboard : MonoBehaviour
{
    public struct Notification
    {
        public int id;
        public string noticeType;                // Notification from a person, or website
        public string name;                     // Name to appear in notification (Sophie, Facebook, LinkedIn News)
        public string noticeMessage;           // Their message to appear in notification 
    }

    public GameObject notificationPrefab;
    public List<Notification> notificationList;
    public bool noNotifications;

    public const int NumberOfNoticesShown = 3;
    public const int MaxCharacters = 50;

    // Start is called before the first frame update
    void Start()
    {
        notificationList = new List<Notification>();
        noNotifications = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (notificationList.Count < 1)
        {
            GameObject.Find("NoNotifications").SetActive(false);
            // Display first 3 notifications on overview
            for (int i = 0; i < NumberOfNoticesShown; i++)
            {
                if (i < notificationList.Count) {
                    GameObject.Find("name"+i).GetComponent<TextMesh>().text = notificationList[i].name;

                    string value = notificationList[i].noticeMessage;
                    string tempString = value.Length <= MaxCharacters ? value : value.Substring(0, MaxCharacters) + "...";
                    GameObject.Find("noticeMessage" + i).GetComponent<TextMesh>().text = tempString;

                    GameObject.Find("notice"+i).SetActive(true);
                } else {
                    GameObject.Find("notice"+i).SetActive(false); 
                }
            }
        } else {
            GameObject.Find("NoNotifications").SetActive(true);
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

        // Remove specified element in list
        RemoveSpecifiedElement(notificationList[res]);
    }
    
    // Creates a new notification game object
    void GenerateNoticeObject(Notification notification)
    {
        GameObject notice = Instantiate(notificationPrefab, gameObject.transform.position, Quaternion.identity);

        notice.GetComponentInChildren<Transform>().Find("name").GetComponent<TextMesh>().text = notification.name;
        notice.GetComponentInChildren<Transform>().Find("noticeMessage").GetComponent<TextMesh>().text = notification.noticeMessage;

    }
}
