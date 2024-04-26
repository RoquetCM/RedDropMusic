using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{

    public static General instance;

    protected int golpesBarricada;

    protected int[] oleadasController;

    protected int contadorFormigasBarricada;

    protected int oleadaActual;

    protected bool parryHura;

    public void SetOleadaActual(int g)
    {

        oleadaActual = g;
    }
    public int GetOleadaActual()
    {
        return oleadaActual;
    }
    public void SetContadorFormigasBarricada(int b)
    {
        contadorFormigasBarricada = b;
    }
    public int GetContadorFormigasBarricada()
    {
        return contadorFormigasBarricada;
    }

    public void SetOleadasController(int[] l)
    {
        oleadasController = l;
    }
    public int[] GetOleadasController()
    {
        return oleadasController;
    }
    public void SetGolpesBarricada(int z)
    {
        golpesBarricada = z;
    }
    public int GetGolpesBarricada()
    {
        return golpesBarricada;
    }

    private void Awake()
    {
        instance = this;
        golpesBarricada = 0;
        
    }


    public void SetParryHura(bool w)
    {

        parryHura = w;
    }
    public bool GetParryHura()
    {
        return parryHura;
    }
}
