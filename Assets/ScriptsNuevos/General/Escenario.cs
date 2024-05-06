using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario : MonoBehaviour
{
    [SerializeField]
    protected float velocidadEscenario;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        this.gameObject.transform.Translate(velocidadEscenario * Time.deltaTime, 0, 0);

    }
}
