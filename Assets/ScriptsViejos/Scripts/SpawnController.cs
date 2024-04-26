using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    protected GameObject furmiga;//El objeto de formiga
    [SerializeField]
    protected GameObject furmigaClon;//que tiene que clonar
    protected int carrilAleatorio;//Uno de los carriles aleatorios
    protected int carrilAleatorio2;//Otro carril aleatorio

    

    void Start()
    {
       
    }
    public void SpawnearFurmigaRandom1()
    {
        // esta variable tine ahotra un valor de 0 a 2 (es decir el numero de carriles que hay).
        carrilAleatorio = Random.Range(0, this.gameObject.transform.childCount);
        // creacion de un clon de formiga, en un punto de spawn.
        furmigaClon = (GameObject)Instantiate(furmiga, this.gameObject.transform.GetChild(carrilAleatorio).transform.position, Quaternion.identity);
        
    }
    public void SpawnearFurmigaRandom2()
    {
        // esta variable tine ahora un valor de 0 a 2 (es decir el numero de carriles que hay).
        carrilAleatorio = Random.Range(0, this.gameObject.transform.childCount);
        carrilAleatorio2 = carrilAleatorio + 1;

        //Si a salido el ultimo carril hacemos que valla al carril 0
        if(carrilAleatorio== this.gameObject.transform.childCount - 1)
        {
            carrilAleatorio2 = 0;
        }

        // creacion de un clon de formiga, en un punto de spawn.
        furmigaClon = (GameObject)Instantiate(furmiga, this.gameObject.transform.GetChild(carrilAleatorio).transform.position, Quaternion.identity);
        furmigaClon = (GameObject)Instantiate(furmiga, this.gameObject.transform.GetChild(carrilAleatorio2).transform.position, Quaternion.identity);
    }

    void Update()
    {
        
     
    }
}
