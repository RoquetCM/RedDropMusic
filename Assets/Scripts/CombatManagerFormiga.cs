using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManagerFormiga : MonoBehaviour
{
    protected bool bloquearPorParry;

    public static CombatManagerFormiga instance;

    [SerializeField]
    protected bool permitirDanio;

    private void Awake()
    {
        instance = this;
        bloquearPorParry = false;
    }
    void Start()
    {
        permitirDanio=false;
    }

    public void SetPermitirDanio(bool g)
    {
        permitirDanio = g;
    }
    public bool GetPermitirDanio()
    {
        return permitirDanio;
    }

    public void SetBloquearPorParry(bool g)
    {
        bloquearPorParry = g;
    }
    public bool GetBloquearPorParry()
    {
        return bloquearPorParry;
    }
}
