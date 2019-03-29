using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backspace : MonoBehaviour
{
    public Material standardColor;
    public Material pressedColor;

    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = pressedColor;
        string text = gameObject.transform.parent.Find("InsertText").transform.Find("CreatedText").GetComponent<TextMesh>().text;
        if (text.Length > 0)
        {
            gameObject.transform.parent.Find("InsertText").transform.Find("CreatedText").GetComponent<TextMesh>().text = text.Substring(0, text.Length - 1);
        }
    }

    void OnTriggerExit(Collider other)
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
        
    }
}
