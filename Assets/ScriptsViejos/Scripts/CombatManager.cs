using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    

    public static CombatManager instance;
    
    
    protected bool puederecibirInput;

    protected bool bloquearPorMamporro;

    protected bool inputRecibido;

    protected bool permitirMovimiento;
    [SerializeField]
    protected bool permitirDanio;


    public void SetBloquearPorMamporro(bool k)
    {
        bloquearPorMamporro = k;
    }
    public bool GetBloquearPorMamporro()
    {
       return bloquearPorMamporro;
    }

    public void SetPuederecibirInput(bool g)
    {
        puederecibirInput = g;
    }
    public bool GetPuederecibirInput()
    {
        return puederecibirInput;
    }
    public void SetPermitirDanio(bool g)
    {
        permitirDanio = g;
    }
    public bool GetPermitirDanio()
    {
        return permitirDanio;
    }
    public void SetInputRecibido(bool e)
    {
        inputRecibido = e;
    }
    public bool GetInputRecibido()
    {
        return inputRecibido;
    }
    public void SetPermitirMovimiento(bool t)
    {
        permitirMovimiento = t;
    }
    public bool GetPermitirMovimiento()
    {
        return permitirMovimiento;
    }


    private void Awake()
    {

        instance = this;
        puederecibirInput = true;
        permitirMovimiento = true;
        permitirDanio = false;
        bloquearPorMamporro = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ataque();
    }

    public void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            if (puederecibirInput)
            {
                inputRecibido = true;
                puederecibirInput = false;
            }
            else
            {
                return;
            }
        }
    }

    public void inputManager()
    {

        if (!puederecibirInput)
        {
            puederecibirInput = true;
        }
        else
        {
            puederecibirInput = false;
        }

    }
}
