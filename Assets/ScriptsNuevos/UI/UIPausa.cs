using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIPausa : MonoBehaviour
{
    [SerializeField]
    protected GameObject camvasSalir;
    
    
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void PulsarBotonExit()
    {
        camvasSalir.SetActive(true);
    }
    public void Continuar()
    {
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
