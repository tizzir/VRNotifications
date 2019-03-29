using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public string key;

    public Material standardColor;
    public Material pressedColor;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Pointer")
        {
            // Update text
            gameObject.transform.parent.Find("InsertText").transform.Find("CreatedText").GetComponent<TextMesh>().text += key;

            // Change color of button to indicate pressed
            gameObject.GetComponent<MeshRenderer>().material = pressedColor;
         
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Change color back
        gameObject.GetComponent<MeshRenderer>().material = standardColor;
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
