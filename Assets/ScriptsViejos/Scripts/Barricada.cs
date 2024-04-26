using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricada : MonoBehaviour
{
    [SerializeField]
    protected int golpesBarricada;//golpes que tines que darle a la barricada

    [SerializeField]
    protected Sprite[] fases;

    protected int golpesTrasGolpe;

    protected bool bloquearGolpeBarricada;

    


    // Start is called before the first frame update
    void Start()
    {
        

        golpesBarricada = 5;
        bloquearGolpeBarricada = true;
    }
    public void DesbloquearGolpesBarricada()
    {
        bloquearGolpeBarricada = false;
        Debug.Log("estoy aqui????");
    }
    public void Golpes(int carrilActual)
    {
        if (bloquearGolpeBarricada == false)
        {

            if ((this.gameObject.tag == "BarricadaD" && carrilActual == 0) || (this.gameObject.tag == "BarricadaI" && carrilActual == 1))
            {
                golpesTrasGolpe = General.instance.GetGolpesBarricada() - 1;
                General.instance.SetGolpesBarricada(golpesTrasGolpe);
                Debug.Log("golpesBarricada" + golpesTrasGolpe);

                if (General.instance.GetGolpesBarricada() == 3)
                {
                    Debug.Log("ayuda" + golpesTrasGolpe);
                    this.transform.parent.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = fases[0];
                }

                else if (General.instance.GetGolpesBarricada() == 1)
                {
                    this.transform.parent.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = fases[1];
                }

                else if (General.instance.GetGolpesBarricada() == 0)
                {
                    General.instance.SetOleadaActual(-1);
                    General.instance.SetContadorFormigasBarricada(0);
                    General.instance.SetGolpesBarricada(0);
                    golpesTrasGolpe = 5;
                    Destroy(this.transform.parent.gameObject);

                }

            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
