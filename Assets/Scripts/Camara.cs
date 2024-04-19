using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [Header("Valores Numericos")]
    [Tooltip("A que tengo que seguir")]
    [SerializeField]
    protected Transform hura;//Lugar del mundo donde esta el jugador (Hura)
    protected float velocidadSeguimiento = 5f;//Velocidad de la camara al se

    protected bool bloquearCamara;

    [Space]
    [Space]
    protected Camera camara;//objeto en el ispector para asignar.
 
    // Start is called before the first frame update
    void Start()
    {
        if (camara == null)
        {
            camara = Camera.main;
        }
    }
    public void BloquearCamara(bool b)
    {
        bloquearCamara = b;
    }

    // Update is called once per frame
    void Update()
    {
        if (bloquearCamara == false)
        {
            Vector3 nuevaPosicion = new Vector3(hura.position.x, this.transform.position.y, transform.position.z);


            transform.position = Vector3.Lerp(transform.position, nuevaPosicion, velocidadSeguimiento * Time.deltaTime);
        }
        

        /*Vector3 posicionActual = transform.position;
 
        float alturaDeseada = 3.016084f;
        posicionActual.y = alturaDeseada;

        
        transform.position = posicionActual;*/
    }
}

