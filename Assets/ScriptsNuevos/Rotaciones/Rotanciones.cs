using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotanciones : MonoBehaviour
{
    [SerializeField]
    protected float velocidadRotativa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, 0, velocidadRotativa * Time.deltaTime);
    }
}
