using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ren2D : MonoBehaviour
{
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
    protected GameObject sangreMusicalRen;
    protected GameObject sangreMusicalCloneRen;
    void Start()
    {
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

    void Update()
    {
        if (estoyMuerto == false)
        {
            this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
            this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
            this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");

            Ataque();
            Pausa();

        }

    }
    
    public void Pausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelPausa.activeSelf==false) 
            {
                GeneralMusical.instance.SetPararJuego(true);
                panelPausa.SetActive(true);
            }
            else
            {
                GeneralMusical.instance.SetPararJuego(false);
                panelPausa.SetActive(false);
            }
        }
    }
    public void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
            this.gameObject.transform.GetChild(2).GetComponent<RenAtaques>().Danyar();
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.J))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");
            this.gameObject.transform.GetChild(0).GetComponent<RenAtaques>().Danyar();
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
            this.gameObject.transform.GetChild(1).GetComponent<RenAtaques>().Danyar();
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    public void Hostion(int hostia)
    {

        if (estoyMuerto == false)
        {
            sangreMusicalCloneRen = (GameObject)Instantiate(sangreMusicalRen, this.gameObject.transform.position, Quaternion.identity);
            Destroy(sangreMusicalCloneRen, 1.0f);
            vida = vida - hostia;
            barraDeVida.GetComponent<Animator>().SetTrigger("EfectoPupa");
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("golpe");
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
}
