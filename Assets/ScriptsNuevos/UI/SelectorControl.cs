using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorControl : MonoBehaviour
{
    public void Seleccionar(int opcion)
    {
        PlayerPrefs.SetInt("CONTROLES", opcion);
    }
}
