using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Extra : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Extra")
        {
            Fungus.Flowchart.BroadcastFungusMessage("Extra");
        }
        else if (other.gameObject.tag == "Fase1")
        {
            Fungus.Flowchart.BroadcastFungusMessage("Fase1");
        }
        else if (other.gameObject.tag == "Fase2")
        {
            Fungus.Flowchart.BroadcastFungusMessage("Fase2");
        }
        else if (other.gameObject.tag == "Fase3")
        {
            Fungus.Flowchart.BroadcastFungusMessage("Fase3");
        }
    }
}
