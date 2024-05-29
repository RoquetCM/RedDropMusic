using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ren2D : MonoBehaviour
{

    protected int ataquerandom;
    protected bool estoyMuerto;
    protected float vida;
    [SerializeField]
    protected GameObject barraDeVida;
    [SerializeField]
    protected GameObject camvaGameOver;
    [SerializeField]
    protected GameObject panelPausa;
    protected float vidaMaxima;

    [SerializeField]
    protected GameObject puntuacionUI;
    [SerializeField]
    protected GameObject combosUI;

    [SerializeField]
    protected GameObject sangreMusicalRen;
    protected GameObject sangreMusicalCloneRen;

    [SerializeField]
    protected Color normal;
    [SerializeField]
    protected Color enfadado;

    protected int zona;
    protected bool bloquearPausa;

    [SerializeField]
    protected GameObject panelSalir;
    [SerializeField]
    protected GameObject opciones;

    
    protected GameObject musicaFondo;
    [SerializeField]
    protected GameObject canvasPerfecto;



    void Start()
    {
        Invoke("DesbloquearPausaTemporal", 4);
        bloquearPausa = true;
        GeneralMusical.instance.SetPuntuacionUIGeneral(puntuacionUI);
        GeneralMusical.instance.SetComboUIGeneral(combosUI);
        GeneralMusical.instance.SetcanvasPerfecto(canvasPerfecto);
        
        vidaMaxima = 100;
        barraDeVida.GetComponent<Image>().fillAmount = vidaMaxima / 100;
        estoyMuerto = false;
        vida = vidaMaxima;
    }
    public void Perfecto()
    {
        Invoke("Ocultar", 0.3f);
    }
   

    public void Ocultar()
    {
        GeneralMusical.instance.GetCanvasPerfecto().transform.GetChild(0).gameObject.SetActive(false);
        GeneralMusical.instance.GetCanvasPerfecto().transform.GetChild(1).gameObject.SetActive(false);
        GeneralMusical.instance.GetCanvasPerfecto().transform.GetChild(2).gameObject.SetActive(false);
        //puntuacionUI.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void ActivarFuria()
    {
        this.gameObject.transform.GetComponent<Animator>().SetTrigger("enfadado");
        this.gameObject.GetComponent<SpriteRenderer>().color= enfadado;
    }
    public void DesactivarFuria()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = normal;
    }

    void Update()
    {
        if (estoyMuerto == false)
        {
            
            
            Pausa();

        }

    }
    public void DesbloquearPausaTemporal()
    {
        bloquearPausa = false;
    }

    
    
    public void Pausa()
    {
        if (bloquearPausa == false)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (panelPausa.activeSelf == false)
                {
                    this.gameObject.GetComponent<SonidoAtaques>().enabled = false;
                    GeneralMusical.instance.SetPararJuego(true);
                    this.gameObject.transform.GetChild(5).gameObject.GetComponent<CreadorFormigasMusicales>().PausarAudio(true);
                    panelPausa.SetActive(true);
                    opciones.SetActive(false);
                    
                }
                else
                {
                    this.gameObject.GetComponent<SonidoAtaques>().enabled = true;
                    GeneralMusical.instance.SetPararJuego(false);
                    this.gameObject.transform.GetChild(5).gameObject.GetComponent<CreadorFormigasMusicales>().PausarAudio(false);
                    panelPausa.SetActive(false);
                    panelSalir.SetActive(false);
                    opciones.SetActive(false);
                }
            }
        }
        
    }
    public void ZonaAtaque()
    {
        this.gameObject.transform.GetChild(zona).GetComponent<RenAtaques>().Danyar();
    }
   
    public void Hostion(int hostia)
    {

        if (estoyMuerto == false)
        {
            this.gameObject.transform.GetChild(5).gameObject.SetActive(true);
            Invoke("Particulas", 0.2f);
            GeneralMusical.instance.SetFormigasMoridas(0);
            combosUI.gameObject.GetComponent<TMP_Text>().text = "";
            sangreMusicalCloneRen = (GameObject)Instantiate(sangreMusicalRen, this.gameObject.transform.position, Quaternion.identity);
            Destroy(sangreMusicalCloneRen, 1.0f);
            vida = vida - hostia;
            barraDeVida.GetComponent<Animator>().SetTrigger("EfectoPupa");
            //this.gameObject.transform.GetComponent<Animator>().SetTrigger("golpe");
            Invoke("ResetearGolpe", 0.01f);
            barraDeVida.GetComponent<Image>().fillAmount = vida / 100;
            if (vida < 0)
            {

                GeneralMusical.instance.SetPararJuego(true);
                this.gameObject.GetComponent<Animator>().SetTrigger("morir");
                estoyMuerto = true;
                Invoke("BloquearRen",0.5f);
                this.gameObject.GetComponent<Ren2D>().enabled = false;
                camvaGameOver.SetActive(true);
                this.gameObject.transform.GetChild(5).gameObject.GetComponent<CreadorFormigasMusicales>().PararMusica();

            }
        }

    }
    public void Particulas()
    {
        this.gameObject.transform.GetChild(5).gameObject.SetActive(false);
    }
    public void ResetearGolpe()
    {
        this.gameObject.transform.GetComponent<Animator>().ResetTrigger("golpe");
    }
    public void ComerComida(int curaComida)
    {
        vida = vida + curaComida;
        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
        barraDeVida.GetComponent<Animator>().SetTrigger("RecargaGato");
        barraDeVida.GetComponent<Image>().fillAmount = vida / 100;
    }
    public void BloquearRen()
    {
        
        this.gameObject.GetComponent<Animator>().enabled = false;

    }
    public void ActivarAtaque()
    {
        GeneralMusical.instance.SetAtaqueActivado(true);
    }
    public void DesactivarAtaque()
    {
        GeneralMusical.instance.SetAtaqueActivado(false);
    }
}
