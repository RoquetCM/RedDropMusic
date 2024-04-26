using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnBarricadaController : MonoBehaviour
{
    [SerializeField]
    protected GameObject furmiga;
    protected GameObject furmigaClon;
    protected int carrilAleatorio;
    protected int carrilAleatorio2;
    protected int carrilAleatorio3;
    protected bool heCreadoFormiga;

    [SerializeField]
    protected int[] oleadas;


    // Start is called before the first frame update
    void Start()
    {
        heCreadoFormiga = false;
        General.instance.SetContadorFormigasBarricada(0);
        General.instance.SetOleadaActual(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnearBarricadaFurmigaRandom()
    {
        Debug.Log("furmigas:" + General.instance.GetContadorFormigasBarricada());
        Debug.Log("oleada:" + General.instance.GetOleadaActual());

        if (General.instance.GetContadorFormigasBarricada() == 0)
        {
            General.instance.SetOleadaActual(General.instance.GetOleadaActual() + 1);
            

            if(General.instance.GetOleadaActual()>= oleadas.Length)
            {
                this.transform.parent.transform.GetChild(1).GetComponent<Barricada>().DesbloquearGolpesBarricada();
                this.transform.parent.transform.GetChild(2).GetComponent<Barricada>().DesbloquearGolpesBarricada();
            }
            else
            {
                General.instance.SetContadorFormigasBarricada(oleadas[General.instance.GetOleadaActual()]);
                //Debug.Log("inicio" + General.instance.GetContadorFormigasBarricada());

                carrilAleatorio = Random.Range(0, this.gameObject.transform.childCount);
               // Debug.Log("carril aleatorio" + carrilAleatorio);


                for (int i = 0; i < General.instance.GetContadorFormigasBarricada(); i++)
                {
                    carrilAleatorio = carrilAleatorio + 1;
                    if (carrilAleatorio == 6)
                    {
                        carrilAleatorio = 0;
                    }

                    furmigaClon = (GameObject)Instantiate(furmiga, this.gameObject.transform.GetChild(carrilAleatorio).transform.position, Quaternion.identity);
                    furmigaClon.AddComponent<FormigaDeBarricada>();
                    if((carrilAleatorio == 0) || (carrilAleatorio == 1) || (carrilAleatorio == 2))
                    {
                        //this.gameObject.transform.GetChild(0)|| this.gameObject.transform.GetChild(1)|| this.gameObject.transform.GetChild(2)
                        furmigaClon.GetComponent<FormigaCuajada>().SetCarrilActualFormiga(0);
                    }
                    else
                    {
                        furmigaClon.GetComponent<FormigaCuajada>().SetCarrilActualFormiga(1);
                        
                    }

                }
            }
                
        }
        

    }
    
}
