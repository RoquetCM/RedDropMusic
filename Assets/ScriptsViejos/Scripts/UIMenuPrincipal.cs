using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIMenuPrincipal : MonoBehaviour
{
    [SerializeField]
    protected GameObject click;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
