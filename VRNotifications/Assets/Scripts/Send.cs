using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send : MonoBehaviour
{
    public bool enterBuffer;
    public GameObject userMessage;

    public Material standardColor;
    public Material pressedColor;

    public static bool useBuffer = false;
    public static int timer = 0;

    // User hit send
    void OnTriggerEnter()
    {
        if (!useBuffer)
        {
            gameObject.GetComponent<MeshRenderer>().material = pressedColor;
            userMessage.transform.Find("userMessage").GetComponent<TextMesh>().text = gameObject.transform.parent.Find("InsertText").transform.Find("CreatedText").GetComponent<TextMesh>().text;
            gameObject.transform.parent.Find("InsertText").transform.Find("CreatedText").GetComponent<TextMesh>().text = "";
            useBuffer = true;
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
