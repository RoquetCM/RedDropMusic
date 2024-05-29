using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Rendering;

public class Cinematicas : MonoBehaviour
{
    [SerializeField]
    protected float tiempo;
    [SerializeField]
    protected string nombreEscena;
    [SerializeField]
    protected GameObject saltar;



    void Start()
    {
        if (PlayerPrefs.HasKey("VOLUMEN"))
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, PlayerPrefs.GetFloat("VOLUMEN"));
        
        }
        Invoke("SaltamientoEscenas", 5);
        Invoke("CambiarEscenaCinematicas", tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CambiarEscenaCinematicas();
        }
    }
    public void CambiarEscenaCinematicas()
    {
        SceneManager.LoadScene(nombreEscena);

    }
    public void SaltamientoEscenas()
    {
        saltar.SetActive(true);
    }

}
