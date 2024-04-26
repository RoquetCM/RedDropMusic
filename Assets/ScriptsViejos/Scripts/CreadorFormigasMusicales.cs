using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorFormigasMusicales : MonoBehaviour
{
    [SerializeField]
    protected GameObject formiga;//El objeto de formiga
    [SerializeField]
    protected GameObject osamaBinFormiga;//El objeto de formiga
    protected GameObject formigaClon;//que tiene que clonar
    [SerializeField]
    protected GameObject[] posiciones; //0 IZQUIERDA,1 ARRIBA,2 DERECHA.

    void Start()
    {
        
    }

   
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            CrearFormiga(0, 1,4f);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            CrearFormiga(1, 1, 4f);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            CrearFormiga(2, 1, 4f);
        }

    }

    public void CrearFormiga(int posicion,int cantidad,float desplazamiento)
    {
        for(int i=0; i < cantidad; i++)
        {
            if (posicion == 0)
            {
                formigaClon = (GameObject)Instantiate(formiga, posiciones[posicion].gameObject.transform.GetChild(i).transform.position, Quaternion.identity);
                formigaClon.GetComponent<FormigaCuajada>().SetMovimiento(desplazamiento);
            }
            if (posicion == 1)
            {
                formigaClon = (GameObject)Instantiate(osamaBinFormiga, posiciones[posicion].gameObject.transform.GetChild(i).transform.position, Quaternion.identity);
                formigaClon.GetComponent<OsamabinFormiga>().SetMovimiento(desplazamiento);
            }
            if (posicion == 2)
            {
                formigaClon = (GameObject)Instantiate(formiga, posiciones[posicion].gameObject.transform.GetChild(i).transform.position, Quaternion.identity);
                formigaClon.GetComponent<FormigaCuajada>().SetMovimiento(desplazamiento);
            }
            
        }
  
    }
}
