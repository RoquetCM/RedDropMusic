using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UISeleccionDeNiveles : MonoBehaviour
{
    [SerializeField]
    protected GameObject click;

    public void CambiarEscena(string nombreEscena)
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();

        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscena);

        
    }

    
    public void PulsarCerrar()
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();

        this.gameObject.transform.parent.gameObject.SetActive(false);
        Application.Quit();
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
