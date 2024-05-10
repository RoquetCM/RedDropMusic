using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CreadorFormigasMusicales : MonoBehaviour
{
    [SerializeField]
    protected GameObject efectoCambioEscenario1;
    [SerializeField]
    protected GameObject panelVictoria;
    [SerializeField]
    protected GameObject efectoCambioEscenario2;
    [SerializeField]
    protected GameObject camara;
    [SerializeField]
    protected float tiempoCambioEscenario1;
    [SerializeField]
    protected float tiempoCambioEscenario2;
    [SerializeField]
    protected GameObject formigaNormal;//El objeto de formiga
    protected GameObject formigaCreada;
    [SerializeField]
    protected GameObject formigaComilona;
    [SerializeField]
    protected GameObject osamaBinFormiga;//El objeto de formiga
    protected GameObject formigaClon;//que tiene que clonar
    [SerializeField]
    protected GameObject[] posiciones; //0 IZQUIERDA,1 ARRIBA,2 DERECHA.
    [SerializeField]
    protected string nombreFichero = "Cancion1.txt"; // Nombre del archivo que leerás
    protected List<string> notasMusicales = new List<string>(); // Lista para almacenar las líneas del archivo
    protected int contador = 0;
    protected float tiempo = 0;
    protected string[] partes;
    [SerializeField]
    protected GameObject contadorAyer;
    protected int contadorCrono;
    [SerializeField]
    protected GameObject puntucaionUI;
    [SerializeField]
    protected GameObject musica;
    [SerializeField]
    protected GameObject teclasUI;
    protected float tiempoMusica;

    void Start()
    {
        tiempoMusica = 0;
       puntucaionUI.SetActive(false);
        contadorCrono = 3;
        LectorFichero(nombreFichero);
        InvokeRepeating("ComprobarNotasMusicales", 0.0f, 0.1f);
       InvokeRepeating("Crono", 0.0f, 1f);
       Invoke("Teclas", 4);
    }
    public void Teclas()
    {
        teclasUI.SetActive(false);
    }
    public void ComprobarNotasMusicales()
    {
        if (GeneralMusical.instance.GetPararJuego()==false)
        {
            tiempoMusica = tiempoMusica + 0.1f;
            if (tiempoMusica >= tiempoCambioEscenario1 && tiempoMusica< tiempoCambioEscenario2)
            {
                if (efectoCambioEscenario1 != null)
                {
                    efectoCambioEscenario1.SetActive(true);
                    Destroy(efectoCambioEscenario1.gameObject, 0.4f);
                }
                camara.transform.GetChild(0).gameObject.SetActive(false);
                camara.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (tiempoMusica >= tiempoCambioEscenario2)
            {
                if (efectoCambioEscenario2 != null)
                {
                    efectoCambioEscenario2.SetActive(true);
                    Destroy(efectoCambioEscenario2.gameObject, 0.4f);
                }
                camara.transform.GetChild(1).gameObject.SetActive(false);
                camara.transform.GetChild(2).gameObject.SetActive(true);
            }

            if (notasMusicales.Count > 0)
            {
                partes = notasMusicales[0].Split(";");
                if (partes.Length > 1)
                {
                    partes[0] = partes[0].Replace("[", "");
                    partes[0] = partes[0].Replace("]", "");
                    
                    if (tiempo > float.Parse(partes[0]) - 2.7f)//- 2.199999f
                    {
                        if (partes[1] == "D")
                        {
                            CrearFormiga(0, 1, 4f, partes[2]);
                        }
                        if (partes[1] == "I")
                        {
                            CrearFormiga(2, 1, 4f, partes[2]);
                        }
                        if (partes[1] == "A")
                        {
                            CrearFormiga(1, 1, 4f, partes[2]);
                        }
                        notasMusicales.RemoveAt(0);
                        if (notasMusicales.Count <= 0)
                        {
                            Invoke("ActivarPenlVictori", 6);
                            CancelInvoke("ComprobarNotasMusicales");
                        }
                    }
                    tiempo += 0.1f;
                    contador++;
                }
                else
                {
                    //panelVictoria.SetActive(true);
                    CancelInvoke("ComprobarNotasMusicales");
                }
            }
            else
            {
                //panelVictoria.SetActive(true);
                CancelInvoke("ComprobarNotasMusicales");
            }
        }
    }
    public void ActivarPenlVictori()
    {
        panelVictoria.SetActive(true);
    }
    public void LectorFichero(string nombre)
    {
        string filePath = Path.Combine(Application.dataPath+ "/Resources/", nombre);

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    notasMusicales.Add(line); // Agrega cada línea a la lista
                }
            }

            Debug.Log($"Archivo leído con éxito. Total de líneas: {notasMusicales.Count}");
        }
        else
        {
            Debug.LogError($"Archivo no encontrado: {filePath}");
        }


    }

    void Update()
    {

    }
    
    public void CrearFormiga(int posicion, int cantidad, float desplazamiento,string tipo)//N =Nomral,C=Comilona
    {
        if (tipo == "C")
        {
            formigaCreada = formigaComilona;
            
        }
        else
        {
            formigaCreada = formigaNormal;
        }
        for (int i = 0; i < cantidad; i++)
        {
            if (posicion == 0)
            {
                formigaClon = (GameObject)Instantiate(formigaCreada, posiciones[posicion].gameObject.transform.position, Quaternion.identity);
                if (tipo == "C")
                {
                    formigaClon.GetComponent<FormigaComilona>().SetMovimiento(desplazamiento);
                }
                else
                {
                    formigaClon.GetComponent<FormigaMusical>().SetMovimiento(desplazamiento);
                }
                    
            }
            if (posicion == 1)
            {
                formigaClon = (GameObject)Instantiate(osamaBinFormiga, posiciones[posicion].gameObject.transform.position, Quaternion.identity);
                formigaClon.GetComponent<OsamaBinFormigaMusical>().SetMovimiento(desplazamiento);
            }
            if (posicion == 2)
            {
                formigaClon = (GameObject)Instantiate(formigaCreada, posiciones[posicion].gameObject.transform.position, Quaternion.identity);
                if (tipo == "C")
                {
                    formigaClon.GetComponent<FormigaComilona>().SetMovimiento(desplazamiento);
                }
                else
                {
                    formigaClon.GetComponent<FormigaMusical>().SetMovimiento(desplazamiento);
                }
            }


        }

    }
    public void Crono()
    {
        contadorAyer.GetComponent<TMP_Text>().text = contadorCrono.ToString();
        contadorCrono--;
        if (contadorCrono < -1)
        {
            Invoke("ActivarMusica", 0.20f);
            CancelInvoke("Crono");
            contadorAyer.SetActive(false);
        }
    }
    public void ActivarMusica()
    {
        musica.SetActive(true);
    }
}
