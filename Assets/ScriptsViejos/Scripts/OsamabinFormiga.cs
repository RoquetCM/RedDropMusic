using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsamabinFormiga : Enemigo
{
    [SerializeField]
    [Range(0f, 10.0f)]
    protected Vector3 posPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        player = (GameObject)GameObject.FindGameObjectWithTag("Hura");
    }
    public void SetMovimiento(float v)
    {
        this.movimiento = v;
    }
    // Update is called once per frame
    void Update()
    {
        posPlayer = new Vector3(0,player.gameObject.transform.position.y, 0);
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, movimiento * Time.deltaTime);
        if (this.transform.position.x > player.transform.position.x)
        {
            this.transform.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
           
            this.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.transform.GetComponent<SpriteRenderer>().flipX = true;
            this.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
          
            this.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hura")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<SphereCollider>().enabled = true;
        }
        Destroy(this.gameObject, 0.50f);
    }
}
