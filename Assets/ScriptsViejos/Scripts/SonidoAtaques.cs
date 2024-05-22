using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SonidoAtaques : MonoBehaviour
{
    public FMODUnity.EventReference playerStateEventD;
    public FMODUnity.EventReference playerStateEventF;
    public FMODUnity.EventReference playerStateEventI;
    public FMODUnity.EventReference playerStateEventJ;
    public FMODUnity.EventReference playerStateEventK;
    public FMODUnity.EventReference playerStateEventE;
    public FMODUnity.EventReference playerStateEventN;
    public FMODUnity.EventReference playerStateEventM;


    private FMOD.Studio.EventInstance eventoFMODD;
    private FMOD.Studio.EventInstance eventoFMODF;
    private FMOD.Studio.EventInstance eventoFMODI;
    private FMOD.Studio.EventInstance eventoFMODJ;
    private FMOD.Studio.EventInstance eventoFMODK;
    private FMOD.Studio.EventInstance eventoFMODE;
    private FMOD.Studio.EventInstance eventoFMODN;
    private FMOD.Studio.EventInstance eventoFMODM;
    bool reproduciendo = false;

    void Start()
    {
        eventoFMODD = FMODUnity.RuntimeManager.CreateInstance(playerStateEventD);
        eventoFMODF = FMODUnity.RuntimeManager.CreateInstance(playerStateEventF);
        eventoFMODI = FMODUnity.RuntimeManager.CreateInstance(playerStateEventI);
        eventoFMODJ = FMODUnity.RuntimeManager.CreateInstance(playerStateEventJ);
        eventoFMODK = FMODUnity.RuntimeManager.CreateInstance(playerStateEventK);
        eventoFMODE = FMODUnity.RuntimeManager.CreateInstance(playerStateEventE);
        eventoFMODE = FMODUnity.RuntimeManager.CreateInstance(playerStateEventN);
        eventoFMODM = FMODUnity.RuntimeManager.CreateInstance(playerStateEventM);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            eventoFMODD.start();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            eventoFMODF.start();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            eventoFMODI.start();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            eventoFMODJ.start();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            eventoFMODK.start();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            eventoFMODI.start();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            eventoFMODN.start();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!reproduciendo)
            {
                eventoFMODM.start();
                reproduciendo = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            reproduciendo = !reproduciendo;

            if (reproduciendo)
            {
                eventoFMODM.setPaused(false);
            }
            else
            {
                eventoFMODM.setPaused(true);
            }
        }
    }
    void OnDestroy()
    {
        eventoFMODD.release();
        eventoFMODF.release();
        eventoFMODI.release();
        eventoFMODJ.release();
        eventoFMODK.release();
        eventoFMODE.release();
        eventoFMODN.release();
        eventoFMODM.release();
    }
    public void ControladorVolumen()
    {
        eventoFMODD.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
        eventoFMODF.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
        eventoFMODI.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
        eventoFMODJ.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
        eventoFMODK.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
        eventoFMODE.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
        eventoFMODN.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
        eventoFMODM.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
    }
}