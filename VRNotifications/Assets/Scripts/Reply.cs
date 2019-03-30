using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reply : MonoBehaviour
{
    public static bool isKeyboardActive = false;
    public GameObject keyboards;
    public GameObject leftHand;
    public GameObject userMessage;
    public GameObject hmd;

    public Material standardColor;
    public Material pressedColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pointer")
        {
            isKeyboardActive = true;
            GameObject keyboardObject = Instantiate(keyboards, leftHand.transform.position, leftHand.transform.rotation, leftHand.transform);
            //keyboardObject.transform.parent = leftHand.transform;
            //keyboardObject.transform.LookAt(hmd.transform);
            //keyboardObject.transform.localEulerAngles = new Vector3(0, 90f, 120f);
            //keyboardObject.transform.position = new Vector3(0f, 0.01f, 0f);
            keyboardObject.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().material = pressedColor;
            keyboardObject.transform.Find("Keyboard").transform.Find("Send").GetComponent<Send>().setUserMessage(gameObject.transform.parent.Find("UserMessageLength").gameObject);
            keyboardObject.transform.Rotate(0,90,40, Space.Self);
            keyboardObject.transform.Translate(0.0f,0.15f,0.15f, Space.Self);
            keyboardObject.transform.Find("KeyboardShift").transform.Find("Send").GetComponent<Send>().setUserMessage(gameObject.transform.parent.Find("UserMessageLength").gameObject);
            keyboardObject.transform.Find("Keyboard").transform.Find("Send").GetComponent<Send>().setReplyButton(gameObject);
            keyboardObject.transform.Find("KeyboardShift").transform.Find("Send").GetComponent<Send>().setReplyButton(gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = standardColor;
    }
    
    public void setLeftHand(GameObject hand) {
        leftHand = hand;
    }
    
    public void setHMD(GameObject hmdisplay){
        hmd = hmdisplay;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isKeyboardActive) {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.Find("ReplyText").GetComponent<TextMesh>().text = "";
        } else {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.transform.Find("ReplyText").GetComponent<TextMesh>().text = "Reply";
        }
    }
}
