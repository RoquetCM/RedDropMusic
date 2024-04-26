using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaMusical : Enemigo
{
    protected GameObject ren;
    [SerializeField]
    [Range(0f, 10.0f)]
    protected Vector3 posPlayer;
    [SerializeField]
    protected GameObject sangreMusical;
    protected GameObject sangreMusicalClone;
    protected float movimientoOriginal;


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        movimientoOriginal = movimiento;
        ren = (GameObject)GameObject.FindGameObjectWithTag("Ren");
        this.GetComponent<Animator>().SetBool("corriendo", true);
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
            Destroy(this.gameObject);
        }
    }
    public void Curar(int danio)
    {
        ren.gameObject.GetComponent<Ren2D>().ComerComida(20);
        vidaEnemigo = vidaEnemigo - danio;
        Muerte();
    }
    public void Muerte()
    {

        if (vidaEnemigo <= 0)
        {
            //sangreMusicalClone = (GameObject)Instantiate(sangreMusical, this.gameObject.transform.parent.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
            //Destroy(sangreMusicalClone.gameObject, 0.5f);
            movimiento = 0;
            this.gameObject.GetComponent<Animator>().SetTrigger("muerte");
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            Destroy(this.gameObject, 1f);

        }
    }
}

