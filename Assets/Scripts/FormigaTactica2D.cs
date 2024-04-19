using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormigaTactica2D : Enemigo
{
    

  
    // Update is called once per frame
    void Update()
    {

    }
    public void DanioEnemigo(int danio)
    {
        vidaEnemigo = vidaEnemigo - danio;
        if (vidaEnemigo <= 0)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
