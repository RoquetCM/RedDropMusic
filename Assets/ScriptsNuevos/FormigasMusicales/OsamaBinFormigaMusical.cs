using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OsamaBinFormigaMusical : Enemigo
{
    protected GameObject ren;
    [SerializeField]
    [Range(0f, 10.0f)]
    protected Vector3 posPlayer;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    protected bool pupa;
    protected GameObject hura;

    [SerializeField]
    protected GameObject sangreMusical;
    protected GameObject sangreMusicalClone;
    protected float movimientoOriginal;
    protected GameObject puntuacionUI;
    protected GameObject furiaPadre;


    void Start()
    {
        furiaPadre = (GameObject)GameObject.FindGameObjectWithTag("FuriaPadre");
        puntuacionUI = GeneralMusical.instance.GetPuntuacionUIGeneral();
        movimientoOriginal = movimiento;
        ren = (GameObject)GameObject.FindGameObjectWithTag("Ren");
    }


    void Update()
    {
        if (GeneralMusical.instance.GetPararJuego())
        {
            movimiento = 0;

        }
        else
        {
            movimiento = movimientoOriginal;
            //this.GetComponent<Animator>().SetBool("corriendo", true);
        }
        posPlayer = ren.gameObject.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, movimiento * Time.deltaTime);
    }
    public void DanioEnemigo(int danio)
    {
        vidaEnemigo = vidaEnemigo - danio;
        Muerte();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Ren"))
        {
            GeneralMusical.instance.SetFuria(0);
            furiaPadre.GetComponent<Animator>().SetTrigger("golpe");
            furiaPadre.transform.GetChild(0).GetComponent<Image>().fillAmount = GeneralMusical.instance.GetFuria();
            furiaPadre.transform.GetChild(2).GetComponent<Image>().fillAmount = GeneralMusical.instance.GetFuria();
            GeneralMusical.instance.SetFuriaActivada(false);;
            ren.GetComponent<Ren2D>().DesactivarFuria();
            other.gameObject.GetComponent<Ren2D>().Hostion(10);
            Destroy(this.gameObject);

        }
    }
    public void Muerte()
    {

        if (vidaEnemigo <= 0)
        {
            sangreMusicalClone = (GameObject)Instantiate(sangreMusical, this.gameObject.transform.position, Quaternion.identity);
            Destroy(sangreMusicalClone, 1.0f);
            puntuacionUI.GetComponent<Animator>().SetTrigger("golpe");
            Invoke("Efecto", 0.5f);
            GeneralMusical.instance.SetFuria(GeneralMusical.instance.GetFuria() + GeneralMusical.instance.GetIncrementoFuria());
            furiaPadre.GetComponent<Animator>().SetTrigger("golpe");
            furiaPadre.transform.GetChild(0).GetComponent<Image>().fillAmount = GeneralMusical.instance.GetFuria();
            furiaPadre.transform.GetChild(2).GetComponent<Image>().fillAmount = GeneralMusical.instance.GetFuria();
            if (GeneralMusical.instance.GetFuria() >= GeneralMusical.instance.GetFuriaMaxima())
            {
                if (GeneralMusical.instance.GetFuriaActivada() == false)
                {
                    ren.GetComponent<Ren2D>().ActivarFuria();
                    GeneralMusical.instance.SetFuriaActivada(true);
                }
            }
            distancia = Vector2.Distance(this.gameObject.transform.position, ren.gameObject.transform.position);
            if (distancia >= 1.3 && distancia <= 2f)
            {
                if (GeneralMusical.instance.GetFuriaActivada() == false)
                {
                    GeneralMusical.instance.SetPuntuacion(GeneralMusical.instance.GetPuntuacion() + (GeneralMusical.instance.GetPuntuacionGolpe() * GeneralMusical.instance.GetMultiplicador()));
                }
                else
                {
                    GeneralMusical.instance.SetPuntuacion(GeneralMusical.instance.GetPuntuacion() + (GeneralMusical.instance.GetPuntuacionFuria() * GeneralMusical.instance.GetMultiplicador()));
                }
                puntuacionUI.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                ren.GetComponent<Ren2D>().Perfecto();

            }
            else
            {
                if (GeneralMusical.instance.GetFuriaActivada() == false)
                {
                    GeneralMusical.instance.SetPuntuacion(GeneralMusical.instance.GetPuntuacion() + (GeneralMusical.instance.GetPuntuacionGolpe()));
                }
                else
                {
                    GeneralMusical.instance.SetPuntuacion(GeneralMusical.instance.GetPuntuacion() + (GeneralMusical.instance.GetPuntuacionFuria()));
                }
            }
            puntuacionUI.gameObject.GetComponent<TMP_Text>().text = GeneralMusical.instance.GetPuntuacion().ToString();
            movimiento = 0;
            //this.gameObject.GetComponent<Animator>().SetTrigger("muerte");
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            Destroy(this.gameObject, 0.1f);

        }
    }
    public void Efecto()
    {
        furiaPadre.GetComponent<Animator>().ResetTrigger("golpe");
        puntuacionUI.GetComponent<Animator>().ResetTrigger("golpe");
    }
    public void SetMovimiento(float v)
    {
        this.movimientoOriginal = v;
        this.movimiento = v;
    }
}
