using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaFondo : MonoBehaviour
{
    static public bool once_call=false;

    public FMODUnity.EventReference playerStateEventM;

    private FMOD.Studio.EventInstance eventoFMODM;

    [SerializeField]
    protected GameObject click;
    

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("VOLUMEN"))
        {
            eventoFMODM.setVolume(PlayerPrefs.GetFloat("VOLUMEN"));
            AudioListener.volume = PlayerPrefs.GetFloat("VOLUMEN");
        }

    }
    public void JugarNiveles(string nombre)
    {
        //click.gameObject.GetComponent<SonidoClink>().Clicar();
        eventoFMODM.stop(STOP_MODE.IMMEDIATE);
        eventoFMODM.release();
        SceneManager.LoadScene(nombre);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ControladorVolumen(float v)
    {
        eventoFMODM.setVolume(v);
    }
    public void ParaMusicaPorfa()
    {
        eventoFMODM.stop(STOP_MODE.IMMEDIATE);
    }
   public void RuegoIniciarMusica()
    {
        eventoFMODM = FMODUnity.RuntimeManager.CreateInstance(playerStateEventM);


        if (PlayerPrefs.HasKey("VOLUMEN"))
        {
            ControladorVolumen(PlayerPrefs.GetFloat("VOLUMEN"));
            AudioListener.volume = PlayerPrefs.GetFloat("VOLUMEN");
        }
        eventoFMODM.start();
    }
    

}
