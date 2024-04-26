using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    //declarar las variables numericas del enemigo

    protected float danioEnemigo;//Danio que hace el enmigo al jugador 
    protected GameObject player;//onjeto al que tine que hacer danio

    [SerializeField]
    protected int vidaEnemigo;//golpes que tines que darle a FormigaCuajada
    protected float distancia;// distancia con el jugador. 
   
    [SerializeField]
    [Range(0.0f, 5.0f)]
    protected float rango;// a partir de aui vulve a su posicion.
    [SerializeField]
    protected float movimiento;// movimieto de la hormiga 

    
}

