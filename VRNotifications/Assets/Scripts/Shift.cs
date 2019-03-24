using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    public string key;
    public bool shiftPressed;

    public Material standardColor;
    public Material pressedColor;

    void OnTriggerEnter(Collider collider)
    {
        // Shift is pressed
        shiftPressed = true;

        // Change color of button to indicate pressed
        gameObject.GetComponent<MeshRenderer>().material = pressedColor;
        gameObject.transform.parent.parent.Find("KeyboardShift").gameObject.SetActive(true);
        gameObject.transform.parent.parent.Find("Keyboard").gameObject.SetActive(false);
    }

    void OnTriggerStay(Collider collider)
    {
        // Shift is pressed
        shiftPressed = true;

        // Change color of button to indicate pressed
        gameObject.GetComponent<MeshRenderer>().material = pressedColor;
        gameObject.transform.parent.parent.Find("KeyboardShift").gameObject.SetActive(true);
        gameObject.transform.parent.parent.Find("Keyboard").gameObject.SetActive(false);
    }

    void OnTriggerExit(Collider collider)
    {
        // Shift is no longer pressed
        shiftPressed = false;

        // Change color back to normal
        gameObject.GetComponent<MeshRenderer>().material = standardColor;
        gameObject.transform.parent.parent.Find("KeyboardShift").gameObject.SetActive(false);
        gameObject.transform.parent.parent.Find("Keyboard").gameObject.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
