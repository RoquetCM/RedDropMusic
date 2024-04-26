using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenAtaques : MonoBehaviour
{
    [SerializeField]
    protected GameObject golpeEfectoPrefab; //Sistema de particulas de golpe.
    [SerializeField]
    protected float radioGolpe;
    protected int minCarril = 3;
    [SerializeField]
    protected int danioGnerado = 1;


    [SerializeField]
    protected GameObject sangreFormiga;//Como saldra representada la vida el jugador en la pantalla.

    protected GameObject sangreFormigaClon;//Como saldra representada la vida el jugador en la pantalla.

    public void Danyar()
    {

        var contactFilter = new ContactFilter2D();
        contactFilter.NoFilter();
        //Listado de todos los objetos con lo que  colisionado Hura en el ataque
        List<Collider2D> objetosDetectados = new List<Collider2D>();
        //Obtengo los objetos detectados
        Physics2D.OverlapCircle(transform.position, radioGolpe, contactFilter, objetosDetectados);


        //Recorro cada unos de los objetos.
        foreach (Collider2D c in objetosDetectados)
        {
            if (c.gameObject.GetComponent<FormigaMusical>())
            {
                Debug.Log(c.gameObject.tag);
                c.gameObject.GetComponent<FormigaMusical>().DanioEnemigo(1008637680);
            }
            if (c.gameObject.GetComponent<OsamaBinFormigaMusical>())
            {
                Debug.Log(c.gameObject.tag);
                c.gameObject.GetComponent<OsamaBinFormigaMusical>().DanioEnemigo(1008637680);
            }
        }
        objetosDetectados.Clear();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioGolpe);
    }

}
