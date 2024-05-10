using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using static UnityEditor.Profiling.RawFrameDataView;

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

    FMOD.Studio.EventInstance eventoFMOD;

    void Start()
    {
        eventoFMOD = FMODUnity.RuntimeManager.CreateInstance(fmodEventD);
        eventoFMOD = FMODUnity.RuntimeManager.CreateInstance(fmodEventF);
        eventoFMOD = FMODUnity.RuntimeManager.CreateInstance(fmodEventI);
        eventoFMOD = FMODUnity.RuntimeManager.CreateInstance(fmodEventJ);
        eventoFMOD = FMODUnity.RuntimeManager.CreateInstance(fmodEventK);
        eventoFMOD = FMODUnity.RuntimeManager.CreateInstance(fmodEventE);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            eventoFMOD.start();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            eventoFMOD.start();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            eventoFMOD.start();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            eventoFMOD.start();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            eventoFMOD.start();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            eventoFMOD.start();
        }
    }
    void OnDestroy()
    {
        eventoFMOD.release();
    }
}
