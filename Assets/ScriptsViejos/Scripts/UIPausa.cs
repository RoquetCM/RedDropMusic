using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIPausa : MonoBehaviour
{
    [SerializeField]
    protected GameObject camvasSalir;
    [SerializeField]
    protected Button botonReintentar;
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void PulsarBotonExit()
    {
        camvasSalir.SetActive(true);
    }



    // Start is called before the first frame update
    void Start()
    {
        Button reintentar = botonReintentar.GetComponent<Button>();
        reintentar.onClick.AddListener(BotonReintentar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotonReintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
