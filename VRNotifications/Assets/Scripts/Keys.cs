using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public bool startTimer;             // Timer used to not accidently repeat letters when in trigger unless intended
    public int timer; 

    public string key;

    public Material standardColor;
    public Material pressedColor;

    void OnTriggerEnter(Collider collider)
    {
        if (!startTimer)
        {
            // Update text
            gameObject.transform.parent.Find("CreatedText").GetComponent<TextMesh>().text += key;

            // Change color of button to indicate pressed
            gameObject.GetComponent<MeshRenderer>().material = pressedColor;

            // Start the timer
            startTimer = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer += 1;
            if (timer > 60)
            {
                startTimer = false;
            }
        } else
        {
            // Change color back
            gameObject.GetComponent<MeshRenderer>().material = standardColor;

            // Reset timer
            timer = 0;
        }
    }
}
