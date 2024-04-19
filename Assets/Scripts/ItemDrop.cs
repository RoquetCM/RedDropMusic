using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] items;
    int itemActivo;

    void Start()
    {
        itemActivo = Random.Range(0, items.Length);
    }

    public void ItemSuelto()
    {
        Instantiate(items[itemActivo],transform.position,Quaternion.identity);
    }

}
