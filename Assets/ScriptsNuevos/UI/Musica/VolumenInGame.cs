using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumenInGame : MonoBehaviour
{
    [SerializeField]
    protected GameObject ren;
    [SerializeField]
    protected GameObject controladorFormigasMusicales;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("VOLUMEN"))
        {
            this.gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("VOLUMEN");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ControladorVolumen()
    {
        Debug.Log(this.gameObject.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("VOLUMEN", this.gameObject.GetComponent<Slider>().value);
        ren.gameObject.GetComponent<SonidoAtaques>().ControladorVolumen();
        controladorFormigasMusicales.gameObject.GetComponent<CreadorFormigasMusicales>().ControladorVolumen();

    }
}
