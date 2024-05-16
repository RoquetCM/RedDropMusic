using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Metronometro : MonoBehaviour
{
    private float milisegundo;
    private string resultado;

    // Start is called before the first frame update
    void Start()
    {
        milisegundo = 0;
        InvokeRepeating("Tiempo", 0, 0.1f);
        resultado = "";

        //Invoke("ComenzarMusica", 3.0f);
    }
    
   // void ComenzarMusica()
   // {
       // this.gameObject.GetComponent<AudioSource>().Play();
   // }
    void Tiempo()
    {
        milisegundo = milisegundo + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("J");
            resultado = resultado + "[" + milisegundo + "];D;N\n";
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            resultado = resultado + "[" + milisegundo + "];I;N\n";
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("I");
            resultado = resultado + "[" + milisegundo + "];A\n";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            resultado = resultado + "[" + milisegundo + "];A\n";
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            string path = "Assets/Resources/test.txt";
            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(resultado);
            writer.Close();
           
     
            Debug.Log(resultado);
        }*/
        


    }
}
