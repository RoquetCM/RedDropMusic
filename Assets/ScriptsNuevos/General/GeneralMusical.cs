using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMusical : MonoBehaviour
{

    public static GeneralMusical instance;
    public static bool pararJuego;
    public static float puntuacion;
    public static float puntuacionGolpe;
    public static float multiplicador;

    public static float furia;
    public static float incrementoFuria;
    public static float furiaMaxima;
    public static bool furiaActivada;
    public static float puntuacionFuria;
    public static GameObject puntuacionUIGeneral;
    public static bool ataqueActivado;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SetAtaqueActivado(bool p)
    {

        ataqueActivado = p;
    }
    public bool GetAtaqueActivado()
    {
        return ataqueActivado;
    }
    public void SetPararJuego(bool w)
    {

        pararJuego = w;
    }
    public bool GetPararJuego()
    {
        return pararJuego;
    }
    public void SetPuntuacionUIGeneral(GameObject m)
    {

        puntuacionUIGeneral = m;
    }
    public GameObject GetPuntuacionUIGeneral()
    {
        return puntuacionUIGeneral;
    }
    public void SetFuriaActivada(bool h)
    {

        furiaActivada = h;
    }
    public bool GetFuriaActivada()
    {
        return furiaActivada;
    }
    public void SetPuntuacion(float t)
    {

        puntuacion = t;
    }
    public float GetPuntuacion()
    {
        return puntuacion;
    }public void SetPuntuacionFuria(float a)
    {

        puntuacionFuria = a;
    }
    public float GetPuntuacionFuria()
    {
        return puntuacionFuria;
    }


    public void SetPuntuacionGolpe(float y)
    {

        puntuacionGolpe = y;
    }
    public float GetPuntuacionGolpe()
    {
        return puntuacionGolpe;
    }
    public void SetMultiplicador(float p)
    {

        multiplicador = p;
    }
    public float GetMultiplicador()
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
    public void SetFuriaMaxima(float p)
    {

        furiaMaxima = p;
    }
    public float GetFuriaMaxima()
    {
        return furiaMaxima;
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
        incrementoFuria = 0.05f;
        pararJuego = false;
        puntuacion = 0;
        puntuacionGolpe = 100;
        multiplicador = 2;
        furiaMaxima = 1;
        puntuacionFuria = 200;
    }
}
