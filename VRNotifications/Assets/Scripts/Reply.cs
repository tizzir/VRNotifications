using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reply : MonoBehaviour
{
    public static bool isKeyboardActive = false;
    public GameObject keyboards;
    public GameObject leftHand;
    public GameObject userMessage;

    public Material standardColor;
    public Material pressedColor;

    private void OnTriggerEnter(Collider other)
    {
        if (!isKeyboardActive && other.gameObject.name == "Pointer")
        {
            isKeyboardActive = true;
            GameObject keyboardObject = Instantiate(keyboards, leftHand.transform.position, Quaternion.identity);
            keyboardObject.transform.parent = leftHand.transform;
            //keyboardObject.transform.localEulerAngles = new Vector3(0, 90f, 120f);
            //keyboardObject.transform.position = new Vector3(0f, 0.01f, 0f);
            keyboardObject.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().material = pressedColor;
            keyboardObject.transform.Find("Keyboard").transform.Find("Send").GetComponent<Send>().setUserMessage(gameObject.transform.parent.Find("UserMessageLength").gameObject);
            keyboardObject.transform.Find("KeyboardShift").transform.Find("Send").GetComponent<Send>().setUserMessage(gameObject.transform.parent.Find("UserMessageLength").gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = standardColor;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isKeyboardActive)
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
        }
    }
}
