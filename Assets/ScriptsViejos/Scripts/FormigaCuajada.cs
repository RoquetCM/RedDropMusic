using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormigaCuajada: MonoBehaviour
{

    protected GameObject player;//objeto que tenemos que seguir
    [SerializeField]
    [Range(0f, 10.0f)]
    protected float movimiento;//velocidad de desplazamiento
    protected Vector3 posPlayer;

    [SerializeField]
    protected int carrilActualFormiga;
    protected int carrilDestinoFormiga;



    // Start is called before the first frame update
    void Awake()
    {
        //referenciar al jugador de la escenas
        player = (GameObject)GameObject.FindGameObjectWithTag("Hura");

        movimiento = 0;

    }


    // Update is called once per frame

    public int GetCarrilActualFormiga()
    {
        return this.carrilActualFormiga;
    }
    public void SetCarrilActualFormiga(int c)
    {
         this.carrilActualFormiga=c;
    }
    public void SetMovimiento(float v)
    {
        this.movimiento = v;
    }
    void Update()
    {

        posPlayer = new Vector3(player.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.left);

        if (hit.collider != player)

        {
            if (CombatManagerFormiga.instance.GetPermitirDanio() == false && CombatManagerFormiga.instance.GetBloquearPorParry() == false)
            {
                
                //movimiento del enemigo
                this.transform.position = Vector3.MoveTowards(this.transform.position, posPlayer, movimiento * Time.deltaTime);
                this.transform.GetChild(0).GetComponent<Animator>().SetBool("corriendo", true);
                //this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, movimiento * Time.deltaTime);

                if (this.transform.position.x > player.transform.position.x)
                {
                    this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                    this.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                    this.transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                    this.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                    this.transform.GetChild(0).transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
                }

            }
        }
        else
        {
            this.transform.GetChild(0).GetComponent<Animator>().SetBool("corriendo", false);
            movimiento = 0;
        }

        //CambioDeCarril();
    }

   /* void CambioDeCarril()
    {

    }*/
}

