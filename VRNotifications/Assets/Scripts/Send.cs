using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send : MonoBehaviour
{
    public int timer;
    public bool enterBuffer;

    // User hit send
    void OnTriggerEnter()
    {
        if (!enterBuffer)
        {
            gameObject.transform.parent.parent.Find("userMessage").GetComponent<TextMesh>().text += gameObject.transform.parent.Find("CreatedText").GetComponent<TextMesh>().text;
            gameObject.transform.parent.Find("CreatedText").GetComponent<TextMesh>().text = "";

            enterBuffer = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enterBuffer = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enterBuffer)
        {
            timer += 1;
            if (timer >= 60)
            {
                enterBuffer = false;
                timer = 0;
            }
        }
    }
}
