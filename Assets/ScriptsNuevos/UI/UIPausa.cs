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

    public void CambiarEscena(string nombre)
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();
        SceneManager.LoadScene(nombre);
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
