using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Hura : MonoBehaviour
{
    //JUGADOR

    [Header("Valores Numericos")]
    [Range(0f, 5f)]
    [Tooltip("Configuracion de la velocidad")]
    [SerializeField]
    protected float velocidad;//Velodiadad a la que se tiene que mover el juagador en numeros.

    [SerializeField]
    protected float vida;//vida del jugador en numeros.
    [SerializeField]
    protected float vidaMaxima;//vida del jugador al maximo.

    [Range(0f, 5f)]
    [SerializeField]
    protected float potenciaSalto;//la fuerza que tiene que hacer el jugador para poder saltar con numeros.

    [SerializeField]
    protected bool furia;// Aqui sabremos si la furia esta activada o no lo esta.
    protected float danio;// este es el danio que hace el jugador.

    [SerializeField]
    protected GameObject barraDeVida;//Como saldra representada la vida el jugador en la pantalla.

    [SerializeField]
    protected int dondeEstoyMirando;//donde esta mirando el jugador(0 es derecha 1 es ixquierda)

    protected bool estoyMuerto;

    [SerializeField]
    protected GameObject camara;//Como saldra representada la vida el jugador en la pantalla.

    [SerializeField]
    protected GameObject[] michis;

    protected int gatoBotiquin;
    [SerializeField]
    protected int curaGato;

    [Space]
    [Space]
    [Header("Datos Personales")]
    [Tooltip("Nombre del perosnaje")]
    [SerializeField]
    protected string nombre;//nobre de l jugador.

    protected float h;
    protected bool estoysaltando;// Aui vemos si el jugador esta saltando o no lo esta.

    [Header("Daño del persoanje")]
    [SerializeField]
    protected float danioBase = 100f; //Danio con el que empieza el jugador.
    private bool aumentoDeDanioActivado = false;//Aqui vemos si el aumento de daño esta activado o no lo esta. 

    [Multiline]
    [SerializeField]
    protected string descripcion; //descripcion del persoanje(prubas)

    [SerializeField]
    protected Color color1;//Sirve para cambiar el color al jugador(prubas)

    protected bool bloquearParry;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    [SerializeField]
    protected float tiempoBloqueoMamporro = 0.50f;
    [SerializeField]
    protected float velocidadHura = 10.0f;
    [SerializeField]
    protected float velocidadCambioDeCarril = 0.2f;
    [SerializeField]
    protected float curaComida = 5;
    [SerializeField]
    protected GameObject camvaGameOver;
    [SerializeField]
    protected GameObject camvaPausa;
    protected bool bloquearPausa;



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Carriles
    [Space]
    [Space]
    [Header("Carriles")]
    [SerializeField]
    protected GameObject[] carriles;//Lista de carriles
    protected int carrilActual; //Carril en el que se encunetra 
    protected Vector3 posicionInicial;//Posicion en la cual empiaza el jugador
    protected Vector3 posicionActual;//Posicion en la que se encuentra el jugador
    protected Vector3 posicionDestino;//Posicion a la ual el jugador va a ir
    [SerializeField]
    protected float velocidadCambioCarril;//Velocidad a la que el jugador se mueve entre carriles
    protected bool bloquearMovimientoCarril;//Tiempo en el que se bloquea el cambio de carril

    protected Vector3 posicionInicialSpawner;//Posicion del Spawner 

    
    protected GameObject objetoDesactivarI;
    
    protected GameObject objetoDesactivarD;

    //protected string email="javisoftworld@gmail.com";


    void Start()
    {
        bloquearPausa = false;
        curaGato = 20;
        bloquearParry = false;
        gatoBotiquin = -1;

        CombatManager.instance.SetPermitirMovimiento(false);
        estoyMuerto = false;
        vida = 100;
        //barraDeVida.GetComponent<Slider>().value = vida;
        barraDeVida.GetComponent<Image>().fillAmount = vida / 100;
        //esto le añada un fuerza para que pueda moverse.
        velocidad = velocidadHura;
        h = 0.0f;
        //A qui podemos ver si el persoanje esta saltando
        estoysaltando = false;
        //aqui mirar en que carril estamos 
        carrilActual = 1;

        posicionInicial = this.gameObject.transform.position;
        bloquearMovimientoCarril = false;

        posicionInicialSpawner = this.transform.GetChild(1).transform.position;
        this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);

        dondeEstoyMirando = 1;
    }
    void Movimiento() 
    {
        //El perosnaje se podra mover usando las "teclas horizontales"
        h = velocidad * Time.deltaTime * Input.GetAxis("Horizontal");
        this.gameObject.transform.Translate(h, 0.0f, 0.0f);
        if (h > 0.0f)
        {
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("estadoPersonaje", 1);
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
            dondeEstoyMirando = 1;
        }
        else if (h < 0.0f)
        {
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("estadoPersonaje", 1);
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(0).transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
            dondeEstoyMirando = 0;
        }
        else
        {
           if (CombatManager.instance.GetPermitirDanio())
           {
                if (dondeEstoyMirando == 1)
                {
                    this.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    this.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
                } 
           }
            else
            {
                this.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
            }
          

            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("estadoPersonaje", -1);
           
        }

        this.transform.GetChild(1).transform.position = new Vector3(this.transform.GetChild(1).transform.position.x, posicionInicialSpawner.y, posicionInicialSpawner.z);
    }
    void Saltar()
    {
       /*// le añade un fuerza para que pueda saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!estoysaltando)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, potenciaSalto, 0);
                estoysaltando = true;
            }
        }*/
    }
    void Furia()
    {
        //al presionar la tecla "R" se "aumentara el daño"
        if (Input.GetKeyDown(KeyCode.I))
        {

            aumentoDeDanioActivado = !aumentoDeDanioActivado;


            if (aumentoDeDanioActivado)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("enfadado");
                danioBase *= 1.2f;
                Debug.Log("Aumento de daño activado. Nuevo valor de daño: " + danioBase);
                //barraDeVida.GetComponent<Image>().fillAmount = vida / 100;
                //

            }
            else
            {

                danioBase = 100f;
                Debug.Log("Aumento de daño desactivado. Valor de daño restablecido a: " + danioBase);
            }
        }

    }
    void CambioDeCarril()
    {

        
       //Aqqui podemosver como el personaje cambia de carril y caunto tarda estando en los carriles
        if (bloquearMovimientoCarril == false)
        {
            if (carrilActual == 0)
            {
                if (objetoDesactivarD)
                {
                    objetoDesactivarD.SetActive(true);
                    objetoDesactivarI.SetActive(false);
                }
                // aqui tenemos que desacctivar lo que recibe daño del carril derecho 
                
            }
            else if (carrilActual == 1)
            {
                if (objetoDesactivarI)
                {
                    // aqui tenemos que desacctivar lo que recibe daño del carril izquierdo
                    objetoDesactivarD.SetActive(false);
                    objetoDesactivarI.SetActive(true);
                }
            }
                    
                    
            if (Input.GetAxis("Vertical") > velocidadCambioDeCarril)
            {
                if (carrilActual == 0)
                {
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("cambioCarril");
                }
                bloquearMovimientoCarril = true;
                carrilActual += 1;
                if (carrilActual >= carriles.Length)
                {
                    carrilActual = carriles.Length - 1;
                }
               
                
            }
            else if (Input.GetAxis("Vertical") < -velocidadCambioDeCarril)
            {
                if (carrilActual == 1)
                {
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("cambioCarril");
                }
                bloquearMovimientoCarril = true;
                carrilActual -= 1;
                if (carrilActual <= 0)
                {
                    carrilActual = 0;
                }
                
            }
        }
        
        posicionActual = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        posicionDestino = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, carriles[carrilActual].gameObject.transform.position.z);
        if (Vector3.Distance(posicionActual, posicionDestino) >= 0.1f && bloquearMovimientoCarril)
        {

            this.gameObject.transform.position = Vector3.MoveTowards(posicionActual, posicionDestino, velocidadCambioCarril * Time.deltaTime);
        }
        else
        {
            this.gameObject.transform.position= new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, carriles[carrilActual].gameObject.transform.position.z);
            bloquearMovimientoCarril = false;
        }
      
    }
    public void Pausa()
    {
        bloquearPausa = false;
        Time.timeScale = 0f;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CombatManager.instance.GetPermitirDanio();
            this.gameObject.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
        }
    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bloquearPausa == false)
            {
                if (camvaPausa.activeSelf)
                {
                    camvaPausa.SetActive(false);
                    Time.timeScale = 1f;
                }
                else
                {
                    bloquearPausa = true;
                    camvaPausa.SetActive(true);
                    Invoke("Pausa", 0.50f);
                }
            }
        }
           
        if (Input.GetKeyDown(KeyCode.M))
        {
            vida = vidaMaxima;
            barraDeVida.GetComponent<Image>().fillAmount = vida / 100;
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            vida = vida-20;
            barraDeVida.GetComponent<Image>().fillAmount = vida/100;
        }

        if (estoyMuerto == false)
        {

            if (CombatManager.instance.GetPermitirMovimiento() && CombatManager.instance.GetBloquearPorMamporro() == false)
            {

                //Movimiento();
                //CambioDeCarril();
                //Parry();
                
            }
            if (CombatManager.instance.GetBloquearPorMamporro() == false)
            {
                Furia();
                Ataque();
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gatoBotiquin >= 0)
            {
                michis[gatoBotiquin].SetActive(false);

                gatoBotiquin=gatoBotiquin-1;
                vida = vida + curaGato;
                if (vida > vidaMaxima)
                {
                    vida = vidaMaxima;
                }
                barraDeVida.GetComponent<Animator>().SetTrigger("RecargaGato");
                barraDeVida.GetComponent<Image>().fillAmount = vida / 100;
            }
            
           
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        //Aqui podemos ver con que contacta el jugagacor colisionandose contr ellos 
        if (other.gameObject.tag == "Suelo")
        {
            //Hasta que no toque el sulo otra vez no podra saltar
            estoysaltando = false;


        }
        if (other.gameObject.tag == "Barricada")
        {
            objetoDesactivarI = other.gameObject.transform.parent.transform.GetChild(2).gameObject;
            objetoDesactivarD = other.gameObject.transform.parent.transform.GetChild(1).gameObject;

            //Una vez choque contra la baaricada esta hara que spwnen los enemigos.
            other.gameObject.GetComponent<SpawnBarricadaController>().SpawnearBarricadaFurmigaRandom();
            General.instance.SetGolpesBarricada(5);


        }

        if (other.gameObject.tag == "FormigaCuajada")
        {
            
            Hostion(20);
        } 
       
     
        


    }
    public void Hostion(int hostia)
    {
        
        if (estoyMuerto == false && General.instance.GetParryHura()==false)
        {

            CombatManager.instance.SetBloquearPorMamporro(true);
            CombatManager.instance.SetPuederecibirInput(false);
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().ResetTrigger("finMamporro");
            Invoke("DesbloquearPorMamporro", tiempoBloqueoMamporro);
            vida = vida - hostia;
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("mamporro");
            barraDeVida.GetComponent<Animator>().SetTrigger("EfectoPupa");
            //barraDeVida.GetComponent<Slider>().value = vida;
            barraDeVida.GetComponent<Image>().fillAmount = vida / 100;
            
            if (vida < 0)
            {
                //Destroy(this.gameObject);
                this.gameObject.transform.GetChild(0).GetComponent<Animator>().ResetTrigger("mamporro");

                this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("morir");
                estoyMuerto = true;

                this.gameObject.GetComponent<Hura>().enabled = false;
                camvaGameOver.SetActive(true);

            }
        }

    }
    public void DesbloquearPorMamporro()
    {
        CombatManager.instance.SetBloquearPorMamporro(false);
        CombatManager.instance.SetPuederecibirInput(true);
        this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("finMamporro");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CamaraBloqueada")
        {

            camara.gameObject.GetComponent<Camara>().BloquearCamara(true);
        }
        if (other.gameObject.tag == "CamaraDesbloqueada")
        {

            camara.gameObject.GetComponent<Camara>().BloquearCamara(false);
        }
        if (other.gameObject.tag == "SpawnFurmigaRandom1")
        {
            // Accedr a un hijo con su trasnform y poder accder a su componenete SpawnController y a su metodo SpawnearFurmigaRandom1.
            this.gameObject.transform.GetChild(2).GetComponent<SpawnController>().SpawnearFurmigaRandom1();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "SpawnFurmigaRandom2")
        {
            this.gameObject.transform.GetChild(2).GetComponent<SpawnController>().SpawnearFurmigaRandom2();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "FinalDeNivel1")
        {

            SceneManager.LoadScene("PantallaStart");
        }

        if (other.gameObject.tag == "Comida")
        {

            vida = vida + curaComida;
            if (vida > vidaMaxima)
            {
                vida = vidaMaxima;
            }
            Debug.Log("mi mida es" + vida);
            Destroy(other.gameObject);
            barraDeVida.GetComponent<Animator>().SetTrigger("RecargaGato");
            barraDeVida.GetComponent<Image>().fillAmount = vida / 100;
            //hay que hacer que cuand ocolisiones con la barricada se desactive el scrip para poder acceder a la lista de los enemigos y mirar cuando se han muerto para poder acctivarse para poder romperla.
        }
        if (other.gameObject.tag == "Gato")
        {
            gatoBotiquin=gatoBotiquin+1;
            if (gatoBotiquin <= 2)
            {
                michis[gatoBotiquin].SetActive(true);
                
            }
            else
            {
                gatoBotiquin = 2;
            }
            Destroy(other.gameObject);
        }
    }
    public void Ataque()
    {
        if ( h==0.0f && CombatManager.instance.GetPermitirDanio() )
        {
           // this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("ataque1");
            
            if (dondeEstoyMirando==1)
            {
                this.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<HuraSprite>().Danyar(0);
                CombatManager.instance.SetPermitirDanio(false);
            }
            else 
            {
                this.gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<HuraSprite>().Danyar(0);
                CombatManager.instance.SetPermitirDanio(false);
            }

         
        }
    }
    public void DesbloquearParry()
    {
        bloquearParry = false;
    }
    public void Parry()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (bloquearParry == false)
            {
                bloquearParry = true;
                Invoke("DesbloquearParry",2);
                General.instance.SetParryHura(true);
                this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("parrys", true);
            }
            
             //this.gameObject.transform.GetComponent<CapsuleCollider>().enabled = false;
            
                

        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            General.instance.SetParryHura(false);

            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("parrys", false);
            //this.gameObject.transform.GetComponent<CapsuleCollider>().enabled = true;
            
            
        }
    }
    
}
