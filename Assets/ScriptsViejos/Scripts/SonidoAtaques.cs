using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SonidoAtaques : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string fmodEventD;
    [FMODUnity.EventRef]
    public string fmodEventF;
    [FMODUnity.EventRef]
    public string fmodEventI;
    [FMODUnity.EventRef]
    public string fmodEventJ;
    [FMODUnity.EventRef]
    public string fmodEventK;
    [FMODUnity.EventRef]
    public string fmodEventE;
    [FMODUnity.EventRef]
    public string fmodEventM;
    [FMODUnity.EventRef]
    public string fmodEventN;

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
        eventoFMODD = FMODUnity.RuntimeManager.CreateInstance(fmodEventD);
        eventoFMODF = FMODUnity.RuntimeManager.CreateInstance(fmodEventF);
        eventoFMODI = FMODUnity.RuntimeManager.CreateInstance(fmodEventI);
        eventoFMODJ = FMODUnity.RuntimeManager.CreateInstance(fmodEventJ);
        eventoFMODK = FMODUnity.RuntimeManager.CreateInstance(fmodEventK);
        eventoFMODE = FMODUnity.RuntimeManager.CreateInstance(fmodEventE);
        eventoFMODE = FMODUnity.RuntimeManager.CreateInstance(fmodEventN);
        eventoFMODM = FMODUnity.RuntimeManager.CreateInstance(fmodEventM);
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
            eventoFMODE.start();
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
}