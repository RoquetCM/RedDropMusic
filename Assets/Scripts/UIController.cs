using System.Collections;
//Para cambiar ewscenas
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;


public class UIController : MonoBehaviour
{
    /*
    Listado escenas
    
    Escena Splash 0
    Escena MenuPrincipal 1
    Escena Nivel1 2
    Escena Nivel2 3
    Escena Nivel3 4
    Escena Creditor 5
    Escena SelectorMundos 6
    Escena Configuracion 7
    */

    //ir a escena Splash
    public void IrASplash()
    {
        SceneManager.LoadScene(0);
    }
    //ir a escena MenuPrincipal
    public void IrAMenuPrincipal()
    {
        SceneManager.LoadScene(1);
    }
    //ir a escena Nivel1
    public void IrANivel1()
    {
        SceneManager.LoadScene(2);
    }
    //ir a escena Nivel2
    public void IrANivel2()
    {
        SceneManager.LoadScene(3);
    }
    //ir a escena Nivel3
    public void IrANivel3()
    {
        SceneManager.LoadScene(4);
    }
    //ir a escena Creditor
    public void IrACreditor()
    {
        SceneManager.LoadScene(5);
    }
    // ir a escena SelectorMundos
    public void IrASelectorMundos()
    {
        SceneManager.LoadScene(6);
    }
    // ir a escena Configuracion
    public void IrAConfiguracion()
    {
        SceneManager.LoadScene(7);
    }

    // ir a escena Salir
    public void IrASalir()
    {
        Application.Quit();
    }
}



