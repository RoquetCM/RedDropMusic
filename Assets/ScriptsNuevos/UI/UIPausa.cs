using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIPausa : MonoBehaviour
{
    [SerializeField]
    protected GameObject camvasSalir;

    [SerializeField]
    protected GameObject click;
    
    [SerializeField]
    protected GameObject eventSystemExterior;

    [SerializeField]
    protected GameObject eventSystemInterior;


    public void CerrarEventosExterior()
    {
        eventSystemExterior.SetActive(true);
    }
    public void AbrirEventosExterior()
    {
        eventSystemExterior.SetActive(false);
    }

    public void CerrarEventosInterior()
    {
        eventSystemInterior.SetActive(true);
    }
    public void AbrirEventosInterior()
    {
        eventSystemInterior.SetActive(false);
    }


    public void CambiarEscena(string nombre)
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();
        if (SceneManager.GetActiveScene().name == "Nivel1Ren")
        {
            SceneManager.LoadScene("Nivel1Ren");
           
        }
        else if (SceneManager.GetActiveScene().name == "Nivel2Ren")
        {
            SceneManager.LoadScene("Nivel2Ren");
           
        }
        else if (SceneManager.GetActiveScene().name == "Nivel3Ren")
        {
            SceneManager.LoadScene("Nivel3Ren");
            
        }
        else
        {
            SceneManager.LoadScene(nombre);
        }
        
    }

    public void PulsarBotonExit()
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();
        camvasSalir.SetActive(true);
    }
    public void Continuar()
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();
        GeneralMusical.instance.SetPararJuego(false);
        this.gameObject.SetActive(false);
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
