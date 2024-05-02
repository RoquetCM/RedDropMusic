using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormigaMusical : Enemigo
{
    protected GameObject ren;
    [SerializeField]
    [Range(0f, 10.0f)]
    protected Vector3 posPlayer;
    [SerializeField]
    protected GameObject sangreMusical;
    protected GameObject sangreMusicalClone;
    protected float movimientoOriginal;
    protected GameObject puntuacionUI;
    protected GameObject furiaPadre;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        movimientoOriginal = movimiento;
        ren = (GameObject)GameObject.FindGameObjectWithTag("Ren");
        puntuacionUI = (GameObject)GameObject.FindGameObjectWithTag("Puntuacion");
        furiaPadre = (GameObject)GameObject.FindGameObjectWithTag("FuriaPadre");
        this.GetComponent<Animator>().SetBool("corriendo", true);
    }


    void Update()
    {
        if (GeneralMusical.instance.GetPararJuego())
        {
            movimiento = 0;
            this.GetComponent<Animator>().SetBool("corriendo", false);
        }
        else
        {
            movimiento = movimientoOriginal;
            this.GetComponent<Animator>().SetBool("corriendo", true);
        }
        posPlayer = ren.gameObject.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, movimiento * Time.deltaTime);

        if (this.transform.position.x > ren.transform.position.x)
        {
            this.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            this.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.transform.GetComponent<SpriteRenderer>().flipX = true;
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            this.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Ren"))
        {
            GeneralMusical.instance.SetFuria(0);
            furiaPadre.GetComponent<Animator>().SetTrigger("golpe");
            furiaPadre.transform.GetChild(0).GetComponent<Image>().fillAmount = GeneralMusical.instance.GetFuria();
            furiaPadre.transform.GetChild(2).GetComponent<Image>().fillAmount = GeneralMusical.instance.GetFuria();

            other.gameObject.GetComponent<Ren2D>().Hostion(20);
           Destroy(this.gameObject);
            
        }
    }
    public void DanioEnemigo(int danio)
    {
        vidaEnemigo = vidaEnemigo - danio;
        Muerte();
    }
    public void Muerte()
    {

        if (vidaEnemigo <= 0)
        {
            puntuacionUI.GetComponent<Animator>().SetTrigger("golpe");
            Invoke("Efecto", 0.5f);
            GeneralMusical.instance.SetFuria(GeneralMusical.instance.GetFuria() + GeneralMusical.instance.GetIncrementoFuria());
            furiaPadre.GetComponent<Animator>().SetTrigger("golpe");
            furiaPadre.transform.GetChild(0).GetComponent<Image>().fillAmount = GeneralMusical.instance.GetFuria();
            furiaPadre.transform.GetChild(2).GetComponent<Image>().fillAmount = GeneralMusical.instance.GetFuria();
            GeneralMusical.instance.SetPuntuacion(GeneralMusical.instance.GetPuntuacion() + GeneralMusical.instance.GetPuntuacionGolpe());
            puntuacionUI.gameObject.GetComponent<TMP_Text>().text = GeneralMusical.instance.GetPuntuacion().ToString();
            movimiento = 0;
            this.gameObject.GetComponent<Animator>().SetTrigger("muerte");
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            Destroy(this.gameObject, 1f);

        }
    }
    public void Efecto()
    {
        furiaPadre.GetComponent<Animator>().ResetTrigger("golpe");
        puntuacionUI.GetComponent<Animator>().ResetTrigger("golpe");
    }
}
