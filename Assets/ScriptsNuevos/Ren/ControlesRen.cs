using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesRen : MonoBehaviour
{
    protected int ataquerandom;
    protected int zona;
    void Update()
    {
        if (PlayerPrefs.GetInt("CONTROLES") == 1)
        {
            controles1();
        }
        if (PlayerPrefs.GetInt("CONTROLES") == 2)
        {
            controles2();
        }
        if (PlayerPrefs.GetInt("CONTROLES") == 3)
        {
            controles3();
        }
        if (PlayerPrefs.GetInt("CONTROLES") == 4)
        {
            controles4();
        }
    }

    public void controles3()
    {
        ataquerandom = Random.Range(0, 3);

        if (Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.J) || Input.GetKey(KeyCode.J) && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataquesalto");

            this.gameObject.transform.GetChild(2).GetComponent<RenAtaques>().Danyar();
            zona = 2;
            Invoke("ZonaAtaque", 0f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(0).GetComponent<RenAtaques>().Danyar();
            zona = 0;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);


            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
            }
        }
        else if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(1).GetComponent<RenAtaques>().Danyar();
            zona = 1;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
            }


        }
    }

    public void controles4()
    {
        ataquerandom = Random.Range(0, 3);

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataquesalto");
            this.gameObject.transform.GetChild(2).GetComponent<RenAtaques>().Danyar();
            zona = 2;
            Invoke("ZonaAtaque", 0f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(0).GetComponent<RenAtaques>().Danyar();
            zona = 0;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);


            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
            }

        }

        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(1).GetComponent<RenAtaques>().Danyar();
            zona = 1;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");

            }


        }
    }
    public void controles1()
    {
        ataquerandom = Random.Range(0, 3);

        if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataquesalto");
            this.gameObject.transform.GetChild(2).GetComponent<RenAtaques>().Danyar();
            zona = 2;
            Invoke("ZonaAtaque", 0f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(0).GetComponent<RenAtaques>().Danyar();
            zona = 0;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);


            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
            }

        }

        else if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(1).GetComponent<RenAtaques>().Danyar();
            zona = 1;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque3");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque1");
                this.gameObject.transform.GetComponent<Animator>().ResetTrigger("ataque2");

            }


        }
    }
    public void controles2()
    {
        ataquerandom = Random.Range(0, 3);

        if (Input.GetKey(KeyCode.G) && Input.GetKeyDown(KeyCode.H) || Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.G))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataquesalto");

            this.gameObject.transform.GetChild(2).GetComponent<RenAtaques>().Danyar();
            zona = 2;
            Invoke("ZonaAtaque", 0f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.GetChild(0).GetComponent<RenAtaques>().Danyar();
            zona = 0;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);


            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
            }
        }
        else if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(1).GetComponent<RenAtaques>().Danyar();
            zona = 1;
            Invoke("ZonaAtaque", 0.15f);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

            if (ataquerandom == 0)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque1");

            }
            else if (ataquerandom == 1)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque2");
            }
            else if (ataquerandom == 2)
            {
                this.gameObject.transform.GetComponent<Animator>().SetTrigger("ataque3");
            }


        }
    }
}
