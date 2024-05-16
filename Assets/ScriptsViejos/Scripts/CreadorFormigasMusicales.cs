using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using FMODUnity;
using System.Diagnostics.Tracing;
using FMOD.Studio;

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

    public FMODUnity.EventReference playerStateEventM;
    public FMODUnity.EventReference playerStateEventN;
    public FMODUnity.EventReference playerStateEventL;

    private FMOD.Studio.EventInstance eventoFMODM;


    private FMOD.Studio.EventInstance eventoFMODN;


    private FMOD.Studio.EventInstance eventoFMODL;

    void Start()
    {

        eventoFMODM = FMODUnity.RuntimeManager.CreateInstance(playerStateEventM);
        eventoFMODN = FMODUnity.RuntimeManager.CreateInstance(playerStateEventN);
        eventoFMODL = FMODUnity.RuntimeManager.CreateInstance(playerStateEventL);

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
        if (GeneralMusical.instance.GetPararJuego() == false)
        {
            tiempoMusica = tiempoMusica + 0.1f;
            if (tiempoMusica >= tiempoCambioEscenario1 && tiempoMusica < tiempoCambioEscenario2)
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
                            Invoke("ActivarPenlVictori", 7);

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
        PararMusica();
    }
    public void LectorFichero(string nombre)
    {
        /*string filePath = Path.Combine(Application.dataPath+ "/Resources/", nombre);

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
        }*/
        notasMusicales.Add("[6,099997];D;N");
        notasMusicales.Add("[7,699995];I;N");
        notasMusicales.Add("[9,299999];A;N");
        notasMusicales.Add("[10];D;N");
        notasMusicales.Add("[10,8];I;N");
        notasMusicales.Add("[12,50001];A;N");
        notasMusicales.Add("[14,00002];D;N");
        notasMusicales.Add("[15,70002];I;N");
        notasMusicales.Add("[16,40003];A;N");
        notasMusicales.Add("[17,20003];D;N");
        notasMusicales.Add("[18,90004];I;N");
        notasMusicales.Add("[20,40004];D;N");
        notasMusicales.Add("[22,00005];A;N");
        notasMusicales.Add("[22,70005];D;C");
        notasMusicales.Add("[23,60005];I;N");
        notasMusicales.Add("[25,30006];A;N");
        notasMusicales.Add("[26,80007];I;C");
        notasMusicales.Add("[27,70007];D;C");
        notasMusicales.Add("[28,50007];A;N");
        notasMusicales.Add("[29,30008];I;N");
        notasMusicales.Add("[30,10008];D;N");
        notasMusicales.Add("[30,90008];A;N");
        notasMusicales.Add("[31,70008];I;N");
        notasMusicales.Add("[32,50008];D;C");
        notasMusicales.Add("[33,20007];A;N");
        notasMusicales.Add("[34,00005];I;N");
        notasMusicales.Add("[34,90004];D;N");
        notasMusicales.Add("[35,70003];A;N");
        notasMusicales.Add("[36,50002];I;N");
        notasMusicales.Add("[37,3];A;N");
        notasMusicales.Add("[38,09999];D;N");
        notasMusicales.Add("[38,79998];A;N");
        notasMusicales.Add("[39,59997];I;C");
        notasMusicales.Add("[40,39996];A;N");
        notasMusicales.Add("[41,19994];D;N");
        notasMusicales.Add("[41,99993];A;N");
        notasMusicales.Add("[42,89992];I;C");
        notasMusicales.Add("[43,69991];A;N");
        notasMusicales.Add("[44,49989];D;N");
        notasMusicales.Add("[45,29988];A;N");
        notasMusicales.Add("[46,09987];I;N");
        notasMusicales.Add("[46,89986];A;N");
        notasMusicales.Add("[47,69984];D;N");
        notasMusicales.Add("[48,39983];A;N");
        notasMusicales.Add("[49,29982];I;C");
        notasMusicales.Add("[49,99981];A;N");
        notasMusicales.Add("[50,8998];D;N");
        notasMusicales.Add("[51,59978];I;N");
        notasMusicales.Add("[52,39977];A;N");
        notasMusicales.Add("[53,29976];D;N");
        notasMusicales.Add("[54,09975];I;N");
        notasMusicales.Add("[54,89973];A;N");
        notasMusicales.Add("[55,69972];D;N");
        notasMusicales.Add("[56,59971];A;N");
        notasMusicales.Add("[57,2997];I;N");
        notasMusicales.Add("[58,09969];A;N");
        notasMusicales.Add("[58,89967];D;N");
        notasMusicales.Add("[59,59966];I;N");
        notasMusicales.Add("[60,39965];D;N");
        notasMusicales.Add("[61,19964];I;C");
        notasMusicales.Add("[61,99963];A;N");
        notasMusicales.Add("[62,79961];D;N");
        notasMusicales.Add("[63,5996];I;N");
        notasMusicales.Add("[64,39959];D;N");
        notasMusicales.Add("[65,19958];A;N");
        notasMusicales.Add("[65,99957];I;N");
        notasMusicales.Add("[66,79955];D;N");
        notasMusicales.Add("[67,59954];A;N");
        notasMusicales.Add("[68,39953];D;N");
        notasMusicales.Add("[69,19952];I;N");
        notasMusicales.Add("[70,0995];A;N");
        notasMusicales.Add("[70,79949];D;N");
        notasMusicales.Add("[71,59948];I;N");
        notasMusicales.Add("[72,39947];A;N");
        notasMusicales.Add("[73,19946];D;N");
        notasMusicales.Add("[73,99944];I;N");
        notasMusicales.Add("[74,79943];A;N");
        notasMusicales.Add("[75,59942];D;C");
        notasMusicales.Add("[76,39941];I;N");
        notasMusicales.Add("[77,19939];A;N");
        notasMusicales.Add("[78,09938];D;C");
        notasMusicales.Add("[78,79937];I;N");
        notasMusicales.Add("[79,59936];A;N");
        notasMusicales.Add("[80,39935];D;N");
        notasMusicales.Add("[81,19933];A;N");
        notasMusicales.Add("[82,09932];D;C");
        notasMusicales.Add("[83,89929];I;N");
        notasMusicales.Add("[84,09929];A;N");
        notasMusicales.Add("[85,19927];D;N");
        notasMusicales.Add("[86,79925];A;N");
        notasMusicales.Add("[87,09924];D;N");
        notasMusicales.Add("[88,49922];D;N");
        notasMusicales.Add("[90,1992];A;N");
        notasMusicales.Add("[90,39919];I;N");
        notasMusicales.Add("[91,59917];C");
        notasMusicales.Add("[93,39915];A;N");
        notasMusicales.Add("[93,59914];I;C");
        notasMusicales.Add("[94,09914];D;N");
        notasMusicales.Add("[95,59911];A;N");
        notasMusicales.Add("[96,3991];I;N");
        notasMusicales.Add("[96,7991];A;N");
        notasMusicales.Add("[97,39909];D;N");
        notasMusicales.Add("[97,99908];A;N");
        notasMusicales.Add("[98,79906];D;N");
        notasMusicales.Add("[99,59905];I;N");
        notasMusicales.Add("[100,399];A;N");
        notasMusicales.Add("[101,199];D;N");
        notasMusicales.Add("[101,999];I;N");
        notasMusicales.Add("[102,399];A;N");
        notasMusicales.Add("[102,899];D;N");
        notasMusicales.Add("[103,399];A;N");
        notasMusicales.Add("[103,799];D;N");
        notasMusicales.Add("[104,399];I;N");
        notasMusicales.Add("[105,199];A;N");
        notasMusicales.Add("[105,999];D;N");
        notasMusicales.Add("[106,7989];I;N");
        notasMusicales.Add("[107,5989];D;N");
        notasMusicales.Add("[108,2989];A;N");
        notasMusicales.Add("[108,6989];D;N");
        notasMusicales.Add("[109,1989];I;N");
        notasMusicales.Add("[109,5989];A;N");
        notasMusicales.Add("[110,1989];D;N");
        notasMusicales.Add("[110,7989];I;N");
        notasMusicales.Add("[111,5989];A;N");
        notasMusicales.Add("[112,3989];D;N");
        notasMusicales.Add("[113,1988];I;C");
        notasMusicales.Add("[113,9988];A;N");
        notasMusicales.Add("[114,7988];D;C");
        notasMusicales.Add("[115,1988];I;N");
        notasMusicales.Add("[115,5988];A;N");
        notasMusicales.Add("[116,0988];D;N");
        notasMusicales.Add("[116,4988];I;N");
        notasMusicales.Add("[117,1988];A;N");
        notasMusicales.Add("[117,9988];D;C");
        notasMusicales.Add("[118,7988];I;N");
        notasMusicales.Add("[119,5987];D;N");
        notasMusicales.Add("[120,3987];I;N");
        notasMusicales.Add("[121,0987];A;N");
        notasMusicales.Add("[121,4987];D;N");
        notasMusicales.Add("[122,0987];I;N");
        notasMusicales.Add("[122,4987];A;N");
        notasMusicales.Add("[122,9987];D;N");
        notasMusicales.Add("[123,5987];I;N");
        notasMusicales.Add("[124,3987];A;N");
        notasMusicales.Add("[125,1987];D;N");
        notasMusicales.Add("[125,8987];A;N");
        notasMusicales.Add("[126,6986];D;N");
        notasMusicales.Add("[127,5986];I;N");
        notasMusicales.Add("[127,9986];A;N");
        notasMusicales.Add("[128,9987];D;N");
        notasMusicales.Add("[129,8987];A;N");
        notasMusicales.Add("[130,6988];I;N");
        notasMusicales.Add("[131,5988];A;N");
        notasMusicales.Add("[132,3989];D;N");
        notasMusicales.Add("[133,1989];A;N");
        notasMusicales.Add("[134,399];I;N");
        notasMusicales.Add("[134,699];A;N");
        notasMusicales.Add("[135,5991];D;N");
        notasMusicales.Add("[136,2991];A;N");
        notasMusicales.Add("[137,4992];I;N");
        notasMusicales.Add("[137,8992];A;N");
        notasMusicales.Add("[138,6993];D;N");
        notasMusicales.Add("[139,4993];A;N");
        notasMusicales.Add("[140,7994];I;N");
        notasMusicales.Add("[141,0994];A;N");
        notasMusicales.Add("[141,8995];D;N");
        notasMusicales.Add("[142,6995];A;N");
        notasMusicales.Add("[143,8996];I;N");
        notasMusicales.Add("[144,2996];A;N");
        notasMusicales.Add("[145,1997];D;N");
        notasMusicales.Add("[145,9997];A;N");
        notasMusicales.Add("[147,0998];D;N");
        notasMusicales.Add("[147,4998];I;N");
        notasMusicales.Add("[148,3999];D;N");
        notasMusicales.Add("[149,0999];A;N");
        notasMusicales.Add("[150,3];D;N");
        notasMusicales.Add("[150,7];I;N");
        notasMusicales.Add("[151,5];A;N");
        notasMusicales.Add("[152,3001];D;N");
        notasMusicales.Add("[153,5002];I;N");




    }

    void Update()
    {

    }

    public void CrearFormiga(int posicion, int cantidad, float desplazamiento, string tipo)//N =Nomral,C=Comilona
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
            eventoFMODL.start();
            Invoke("ActivarMusica", 0.20f);
            CancelInvoke("Crono");
            contadorAyer.SetActive(false);
        }
        else
        {
            eventoFMODN.start();
        }
    }
    public void ActivarMusica()
    {
        eventoFMODM.start();
    }
    public void PararMusica()
    {
        eventoFMODM.stop(STOP_MODE.IMMEDIATE);
    }
    public void PausarAudio(bool p)
    {
        eventoFMODM.setPaused(p);
    }
}
