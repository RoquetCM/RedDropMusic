using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectorControl : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("CONTROLES") == true)
        {
            Highlight();
        }
    }
    public void Seleccionar(int opcion)
    {
        PlayerPrefs.SetInt("CONTROLES", opcion);
        Highlight();
    }
    public void Highlight()
    {
        this.gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
        this.gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.white;
        this.gameObject.transform.GetChild(5).gameObject.GetComponent<Image>().color = Color.white;
        this.gameObject.transform.GetChild(7).gameObject.GetComponent<Image>().color = Color.white;
        if (PlayerPrefs.GetInt("CONTROLES") == 1)
        {
            this.gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.red;
        }
        else if (PlayerPrefs.GetInt("CONTROLES") == 2)
        {
            this.gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().color = Color.red;
        }
        else if (PlayerPrefs.GetInt("CONTROLES") == 3)
        {
            this.gameObject.transform.GetChild(5).gameObject.GetComponent<Image>().color = Color.red;
        }
        else if (PlayerPrefs.GetInt("CONTROLES") == 4)
        {
            this.gameObject.transform.GetChild(7).gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
