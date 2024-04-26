using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hura2D : MonoBehaviour
{
   public void QuitarTriggers()
    {
        this.GetComponent<Animator>().ResetTrigger("ataque1");
        this.GetComponent<Animator>().ResetTrigger("ataque2");

    }
}
