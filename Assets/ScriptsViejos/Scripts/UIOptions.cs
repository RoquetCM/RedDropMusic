using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIOptions : MonoBehaviour
{
   [SerializeField]
   protected GameObject Panelsound;
    [SerializeField]
   protected GameObject Panelcontroles;
    [SerializeField]
   protected GameObject Panellanguage;
   


    //Filtros dltonicos
    [SerializeField]
    protected GameObject PanelDeuteranopia;
    [SerializeField]
    protected GameObject PanelProtanopia;
    [SerializeField]
    protected GameObject PanelTritanopia;

    //Ns pero importante
   [SerializeField]
    protected Slider slider;
    [SerializeField]
    protected float sliderValue;
    [SerializeField]
    protected Image panelBrillo;

    //musica
    [SerializeField] Slider volumenslider;
    [SerializeField] Slider musicalider;
    [SerializeField] Slider efectoslider;


    [SerializeField]
    protected GameObject panelPausa;
    [SerializeField]
    protected GameObject opciones;

    [SerializeField]
    protected GameObject click;

    // Start is called before the first frame update
    void Start()
    {
     //Panelsound.SetActive(false);
     Panelcontroles.SetActive(false);
     


        
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);

        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);



        //sound volumen

        if (!PlayerPrefs.HasKey("VOLUMEN"))
        {
            PlayerPrefs.SetFloat("VOLUMEN", 1);
            LoadVolumen();
        }

        else
        {
            LoadVolumen();
        }
        //cositas Musica

        if (!PlayerPrefs.HasKey("MUSICA"))
        {
            PlayerPrefs.SetFloat("MUSICA", 1);
            LoadMusica();
        }

        else
        {
            LoadMusica();
        }
        //cositas efects

        if (!PlayerPrefs.HasKey("EFECTOS"))
        {
            PlayerPrefs.SetFloat("EFECTOS", 1);
            LoadEfectos();
        }

        else
        {
            LoadEfectos();
        }
    }

 

    void Update()
    {
     
    }
   
        public void TogglePanel1()
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();

        // Si el panel está inactivo, lo activamos; si está activo, lo desactivamos
        Panelsound.SetActive(!Panelsound.activeSelf);
        Panelcontroles.SetActive(false);
    }

     public void TogglePanel2()
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();

        // Si el panel está inactivo, lo activamos; si está activo, lo desactivamos
        Panelcontroles.SetActive(!Panelcontroles.activeSelf);
        Panelsound.SetActive(false);
      
    }

     public void TogglePanel4()
    {
        // Si el panel está inactivo, lo activamos; si está activo, lo desactivamos
        
        Panelsound.SetActive(false);
        Panelcontroles.SetActive(false);
    }


    public void Deuteranopia1()
    {
        // Si el panel está inactivo, lo activamos; si está activo, lo desactivamos
        PanelDeuteranopia.SetActive(!PanelDeuteranopia.activeSelf);
        PanelProtanopia.SetActive(false);
        PanelTritanopia.SetActive(false);
    }

    public void Protanopia2()
    {
        // Si el panel está inactivo, lo activamos; si está activo, lo desactivamos
        PanelProtanopia.SetActive(!PanelProtanopia.activeSelf);
        PanelDeuteranopia.SetActive(false);
        PanelTritanopia.SetActive(false);
    }

    public void Tritanopia3()
    {
        // Si el panel está inactivo, lo activamos; si está activo, lo desactivamos
        PanelTritanopia.SetActive(!PanelTritanopia.activeSelf);
        PanelDeuteranopia.SetActive(false);
        PanelProtanopia.SetActive(false);
       
    }


    public void changeSlider(float valor)

    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
    }


    public void CambiarEscena(string nombre)
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();
        SceneManager.LoadScene(nombre);

    }

    // SONIDO VOLUMEN
    public void Cambiarvolumen()
    {
        AudioListener.volume = volumenslider.value;
        SaveVolumen();
    
    }

    public void LoadVolumen()
    {
        //volumenslider.value = PlayerPrefs.GetFloat("VOLUMEN");
    }

    public void SaveVolumen()
    {
        PlayerPrefs.SetFloat("VOLUMEN", volumenslider.value);
    }

    // SONIDO MUSICA
    public void CambiarMusica()
    {
        AudioListener.volume = musicalider.value;
        SaveMusica();

    }

    public void LoadMusica()
    {
        //musicalider.value = PlayerPrefs.GetFloat("MUSICA");
    }

    public void SaveMusica()
    {
        PlayerPrefs.SetFloat("MUSICA", musicalider.value);

    }
    // SONIDO EFECTS
    public void CambiarEfectos()
    {
        AudioListener.volume = efectoslider.value;
        SaveEfectos();

    }

    public void LoadEfectos()
    {
        //efectoslider.value = PlayerPrefs.GetFloat("EFECTOS");
    }

    public void SaveEfectos()
    {
        PlayerPrefs.SetFloat("EFECTOS", efectoslider.value);
    }
    public void VolverPausa()
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();

        panelPausa.SetActive(true);
        opciones.SetActive(false);
    }
}
