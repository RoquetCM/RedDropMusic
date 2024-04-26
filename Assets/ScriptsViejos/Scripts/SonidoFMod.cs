using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFMod : MonoBehaviour
{

    public string Event;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayOneShot()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayOneShot();
        }
    }
}
