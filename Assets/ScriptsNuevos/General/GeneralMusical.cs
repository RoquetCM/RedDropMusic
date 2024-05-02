using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMusical : MonoBehaviour
{

    public static GeneralMusical instance;
    public static bool pararJuego;
    public static int puntuacion;
    public static int puntuacionGolpe;
    public static int multiplicador;

    public static float furia;
    public static float incrementoFuria;
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void SetPararJuego(bool w)
    {

        pararJuego = w;
    }
    public bool GetPararJuego()
    {
        return pararJuego;
    }
    public void SetPuntuacion(int t)
    {

        puntuacion = t;
    }
    public int GetPuntuacion()
    {
        return puntuacion;
    }
    public void SetPuntuacionGolpe(int y)
    {

        puntuacionGolpe = y;
    }
    public int GetPuntuacionGolpe()
    {
        return puntuacionGolpe;
    }
    public void SetMultiplicador(int p)
    {

        multiplicador = p;
    }
    public int GetMultiplicador()
    {
        return multiplicador;
    }
    public void SetFuria(float f)
    {

        furia = f;
    }
    public float GetFuria()
    {
        return furia;
    }
    public void SetIncrementoFuria(float s)
    {

        incrementoFuria = s;
    }
    public float GetIncrementoFuria()
    {
        return incrementoFuria;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        furia = 0;
        incrementoFuria = 0.25f;
        pararJuego = false;
        puntuacion = 0;
        puntuacionGolpe = 100;
        multiplicador = 2;
    }
}
