using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Volumen : MonoBehaviour
{
    protected GameObject musicaFondo;


   
    void Start()
    {
        musicaFondo = (GameObject)GameObject.FindGameObjectWithTag("MusicaFondo");
        print(musicaFondo);
        if (PlayerPrefs.HasKey("VOLUMEN"))
        {
            this.gameObject.GetComponent<Slider>().value=PlayerPrefs.GetFloat("VOLUMEN");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ControladorVolumen()
    {
        PlayerPrefs.SetFloat("VOLUMEN", this.gameObject.GetComponent<Slider>().value);
        musicaFondo.gameObject.GetComponent<MusicaFondo>().ControladorVolumen(this.gameObject.GetComponent<Slider>().value);
    }

}
