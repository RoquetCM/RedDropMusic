using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplicacionRedDrop : MonoBehaviour
{
    [SerializeField]
    protected GameObject explicacion1;
    [SerializeField]
    protected GameObject explicacion2;
    [SerializeField]
    protected GameObject explicacion3;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("PanelesExplicacion1", 20f);
        Invoke("PanelesExplicacion2", 30f);
        Invoke("CargarPantallaStart", 50f);
        

    }
    public void PanelesExplicacion1()
    {
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }
    public void PanelesExplicacion2()
    {
        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }
    public void CargarPantallaStart()
    {
        SceneManager.LoadScene("PantallaStart");
    }
}
