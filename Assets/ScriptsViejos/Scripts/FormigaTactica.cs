using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormigaTactica : Enemigo
{
    protected Vector3 posicionInicial;
    [SerializeField]
    [Range(1f, 10f)]
    protected float distanciaVolver;
    protected bool seguir;

    // Start is called before the first frame update
    void Awake()
    {
        //referenciar al jugador de la escenas y seguimiento

        player = (GameObject)GameObject.FindGameObjectWithTag("Hura");
        posicionInicial = this.transform.position;
        seguir = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento del enemigo y rango

        distancia = Vector3.Distance(this.transform.position, player.transform.position);
        //Debug.Log(distancia);
        if (distancia < rango)
        {
            seguir = true;
          
          
        }
        if (seguir == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, movimiento * Time.deltaTime);
            //this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, movimiento * Time.deltaTime);
        }
    }
}
