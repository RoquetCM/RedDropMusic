using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SonidoClink : MonoBehaviour
{
    public FMODUnity.EventReference playerStateEventClick;

    private FMOD.Studio.EventInstance eventoFMODClick;

    // Start is called before the first frame update
    void Start()
    {
        eventoFMODClick = FMODUnity.RuntimeManager.CreateInstance(playerStateEventClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clicar()
    {
        eventoFMODClick.start();
    }
}
