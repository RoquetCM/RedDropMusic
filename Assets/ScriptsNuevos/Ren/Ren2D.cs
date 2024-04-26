using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        vidaMaxima = 100;
        barraDeVida.GetComponent<Image>().fillAmount = vidaMaxima / 100;
        estoyMuerto = false;
        vida = vidaMaxima;
    }


    void Update()
    {
        Ataque();
        Pausa();
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
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.R))
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
}
