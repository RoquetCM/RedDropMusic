using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesInGame : MonoBehaviour
{
    [SerializeField]
    protected GameObject panelOpcionesJuego;
    [SerializeField]
    protected GameObject panelPausa;

    [SerializeField]
    protected GameObject click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpcionesJuego()
    {
        click.gameObject.GetComponent<SonidoClink>().Clicar();
        panelOpcionesJuego.SetActive(true);
        panelPausa.SetActive(false);
    }
}
