using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosAnimacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PermitirMovimiento()
    {
        CombatManager.instance.SetPermitirMovimiento(true);
        CombatManager.instance.SetPuederecibirInput(true);
    }
    public void PermitirDanio()
    {
        CombatManager.instance.SetPermitirDanio(true);
    }
    public void NoPermitirDanio()
    {
        CombatManager.instance.SetPermitirDanio(false);
    }
}
