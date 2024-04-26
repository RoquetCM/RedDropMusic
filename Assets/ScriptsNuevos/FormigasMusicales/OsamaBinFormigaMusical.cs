using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected GameObject sangreFormiga;
    protected GameObject sangreFormigaClon;
    protected float movimientoOriginal;


    void Start()
    {
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
            this.GetComponent<Animator>().SetBool("corriendo", true);
        }
        posPlayer = ren.gameObject.transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, movimiento * Time.deltaTime);
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
            movimiento = 0;
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            Destroy(this.gameObject, 0.1f);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Ren"))
        {
            other.gameObject.GetComponent<Ren2D>().Hostion(20);
            Destroy(this.gameObject);

        }
    }
}
