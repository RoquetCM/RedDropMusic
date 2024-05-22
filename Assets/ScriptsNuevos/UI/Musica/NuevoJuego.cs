using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoJuego : MonoBehaviour
{
    [SerializeField]
    protected GameObject musicaFondo;
    [SerializeField]
    protected GameObject click;

    // Start is called before the first frame update
    void Start()
    {

        musicaFondo = (GameObject)GameObject.FindGameObjectWithTag("MusicaFondo");
        Invoke("JesusSalvanos",0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuieroJugar()
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();
        musicaFondo.gameObject.GetComponent<MusicaFondo>().JugarNiveles("Nivel1Ren");
    }
    public void JesusSalvanos()
    {
        musicaFondo.gameObject.GetComponent<MusicaFondo>().RuegoIniciarMusica();

    }
}
