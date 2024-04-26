using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ren2D : MonoBehaviour
{
    protected bool estoyMuerto;
    protected float vida;
    [SerializeField]
    protected GameObject barraDeVida;

    void Start()
     {
        estoyMuerto = false;
        vida = 100;
     }

    
    void Update()
    {
        Ataque();
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
    /*public void Hostion(int hostia)
    {

        if (estoyMuerto == false)
        { 
            vida = vida - hostia;
            barraDeVida.GetComponent<Animator>().SetTrigger("EfectoPupa");
            barraDeVida.GetComponent<Image>().fillAmount = vida / 100;

            if (vida < 0)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("morir");
                estoyMuerto = true;

                this.gameObject.GetComponent<Ren2D>().enabled = false;
                camvaGameOver.SetActive(true);

            }
        }

    }*/
}
