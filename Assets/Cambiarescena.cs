using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiarescena : MonoBehaviour
{
    public GameObject Ojo;
    public GameObject Humo;
    public GameObject Click;
    public GameObject Petalos;
    public GameObject Petalos2;
    public float delayTime = 10f; // Tiempo de retraso en segundos


    private void Update()
    {
        Continuar();
    }

    // Start is called before the first frame update
    public void ButtonContinue()
    {
        Click.SetActive(false);
        Humo.SetActive(false);
        Petalos.SetActive(false);
        Petalos2.SetActive(false);
        Ojo.SetActive(true); // Activar el GameObject Ojo

        // Llamar a la función ChangeScene después del retraso
        Invoke("ChangeScene", delayTime);
    }

    public void Continuar()
    {
        if (Input.anyKeyDown)
        {
            Click.SetActive(false);
            Humo.SetActive(false);
            Petalos.SetActive(false);
            Petalos2.SetActive(false);
            Ojo.SetActive(true);
            Invoke("ChangeScene", delayTime);
        }
    }

    // Función para cambiar de escena
    private void ChangeScene()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Cambiar a la escena deseada
    }
}