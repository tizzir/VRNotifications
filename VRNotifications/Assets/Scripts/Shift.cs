using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    public string key;
    public static bool useBuffer = false;
    public static int timer = 0;
    public static bool shiftPressed;

    public Material standardColor;
    public Material pressedColor;

    public GameObject keyboard;
    public GameObject keyboardShift;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Pointer" && !useBuffer)
        {
            // Shift is pressed
            shiftPressed = !shiftPressed;

            // Change color of button to indicate pressed
            gameObject.GetComponent<MeshRenderer>().material = pressedColor;

            useBuffer = true;
        }
    }

    /*void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "Pointer")
        {
            // Shift is pressed
            shiftPressed = true;

            // Change color of button to indicate pressed
            gameObject.GetComponent<MeshRenderer>().material = pressedColor;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Pointer")
        {
            // Shift is no longer pressed
            shiftPressed = false;

            // Change color back to normal
            gameObject.GetComponent<MeshRenderer>().material = standardColor;
        }
    }*/


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shiftPressed)
        {
            keyboardShift.gameObject.SetActive(true);
            keyboard.gameObject.SetActive(false);
        } else
        {
            keyboardShift.gameObject.SetActive(false);
            keyboard.gameObject.SetActive(true);
        }

        if (useBuffer)
        {
            timer += 1;
            if (timer > 30)
            {
                timer = 0;
                useBuffer = false;
            }
        }
    }
}
