using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCreditos : MonoBehaviour
{
    [SerializeField]
    protected
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)|| Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("le he dado al boton");
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
    public void Fin()
    {
    SceneManager.LoadScene("MenuPrincipal");
    }
}
