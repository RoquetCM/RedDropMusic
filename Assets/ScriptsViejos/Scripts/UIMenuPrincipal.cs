using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIMenuPrincipal : MonoBehaviour
{
    [SerializeField]
    protected GameObject click;
    [SerializeField]
    protected GameObject camvasOpcionesMenu;
    [SerializeField]
    protected GameObject letrasCanvasMenu;
    [SerializeField]
    protected GameObject eventSystemExterior;

    public void CerrarOpcionesMenus()
    {
        camvasOpcionesMenu.SetActive(false);
        letrasCanvasMenu.SetActive(true);
        eventSystemExterior.SetActive(true);
    }
    public void OpcionesMenus()
    {
        camvasOpcionesMenu.SetActive(true);
        letrasCanvasMenu.SetActive(false);
        eventSystemExterior.SetActive(false);
    }
    public void CambiarEscena(string nombre)
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();  
        SceneManager.LoadScene(nombre);
    }

    public void PulsarBotonEmpezarCero()
    {
        Debug.Log("empezar");
    }

    public void PulsarBotonSalir()
    {
        Debug.Log("salir");
    }

    public void PulsarBotonContinuar()
    {
        Debug.Log("continuar");
    }

    public void PulsarBotonNivel()
    {
        Debug.Log("nivel");
    }

    public void PulsarBotonOpciones()
    {
        Debug.Log("opciones");
    }

    public void PulsarBotonCreditos()
    {
        Debug.Log("creditos");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CONTROLES") == false)
        {
            PlayerPrefs.SetInt("CONTROLES", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
