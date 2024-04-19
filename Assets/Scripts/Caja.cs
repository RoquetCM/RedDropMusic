using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] comidaAleatoria;
    protected int golpesCaja;

    void Start()
    {
        golpesCaja = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (golpesCaja < 0)
        {

            Destroy(this.gameObject);
        }
    }
}
