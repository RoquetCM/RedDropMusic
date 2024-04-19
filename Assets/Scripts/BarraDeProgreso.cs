using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeProgreso : MonoBehaviour
{

    [SerializeField]
    protected GameObject[] puntos;
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected int puntosLinea;
    protected int contador;


    // Start is called before the first frame update
    void Start()
    {
        contador = 1; //Siempre sera 1
       //puntosLinea = 1;
        puntos[puntosLinea].GetComponent<Image>().color = Color.yellow;
        InvokeRepeating("Incrementar", 1,1);
    }
    
    void Incrementar()
    {
       
        if(contador >= puntosLinea)
        {
            CancelInvoke("Incrementar");
        }
        else
        {
            contador = contador + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, puntos[contador].transform.position, 5*Time.deltaTime);

    }
}
