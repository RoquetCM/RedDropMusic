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



    void Start()
    {
        musicaFondo = (GameObject)GameObject.FindGameObjectWithTag("MusicaFondo");
        musicaFondo.gameObject.GetComponent<MusicaFondo>().ParaMusicaPorfa();
        Invoke("DesbloquearPausaTemporal", 4);
        bloquearPausa = true;
        GeneralMusical.instance.SetPuntuacionUIGeneral(puntuacionUI);
        GeneralMusical.instance.SetComboUIGeneral(combosUI);
        vidaMaxima = 100;
        barraDeVida.GetComponent<Image>().fillAmount = vidaMaxima / 100;
        estoyMuerto = false;
        vida = vidaMaxima;
    }
    public void Perfecto()
    {
        Invoke("Ocultar", 0.5f);
    }
    public void Ocultar()
    {
        
        puntuacionUI.transform.GetChild(0).gameObject.SetActive(false);
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
            
            Ataque();
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
                    GeneralMusical.instance.SetPararJuego(true);
                    this.gameObject.transform.GetChild(5).gameObject.GetComponent<CreadorFormigasMusicales>().PausarAudio(true);
                    panelPausa.SetActive(true);
                    opciones.SetActive(false);
                    
                }
                else
                {
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
    public void Ataque()
    {
        ataquerandom = Random.Range(0, 3);

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataquesalto");
            //this.gameObject.transform.GetChild(2).GetComponent<RenAtaques>().Danyar();
            zona = 2;
            Invoke("ZonaAtaque", 0f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            //this.gameObject.transform.GetChild(0).GetComponent<RenAtaques>().Danyar();
            zona = 0;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);


            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
            }

        }

        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = true;
            //this.gameObject.transform.GetChild(1).GetComponent<RenAtaques>().Danyar();
            zona = 1;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");

            }


        }

    }
    public void Hostion(int hostia)
    {

        if (estoyMuerto == false)
        {
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
