using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Send : MonoBehaviour
{
    public bool enterBuffer;
    public GameObject userMessage;

    public Material standardColor;
    public Material pressedColor;
    
    public GameObject replyButton; 

    public static bool useBuffer = false;
    public static int timer = 0;

    // User hit send
    void OnTriggerEnter(Collider collider)
    {
        if (!useBuffer && collider.gameObject.name == "Pointer")
        {
            try {
                Reply.isKeyboardActive = false;            
                replyButton.SetActive(true);
                gameObject.GetComponent<MeshRenderer>().material = pressedColor;
                userMessage.transform.Find("userMessage").GetComponent<TextMesh>().text = gameObject.transform.parent.Find("InsertText").transform.Find("CreatedText").GetComponent<TextMesh>().text;
                gameObject.transform.parent.Find("InsertText").transform.Find("CreatedText").GetComponent<TextMesh>().text = "";
                useBuffer = true;
            } catch (Exception e) {
                Debug.Log("Exception: "+e);
            }   
            Destroy(gameObject.transform.parent.gameObject);        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = standardColor;
    }

    public void setUserMessage(GameObject messageObject)
    {
        userMessage = messageObject;
    }
    
    public void setReplyButton(GameObject button) {
        replyButton = button;
        replyButton.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            timer += 1;
            if (timer > 30)
            {
                useBuffer = false;
                timer = 0;
            }
        }
    }
}
