using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { MagicMushroom, FireFlower, Coin, Life, Star }
public class Item : MonoBehaviour
{
    public ItemType type;
    bool isCatched;
    public int puntos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isCatched)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                isCatched = true;
                collision.gameObject.GetComponent<Mario>().CatchItem(type);
                CatchItem();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        //{
        //    collision.gameObject.GetComponent<Mario>().CatchItem(type);
        //    Destroy(gameObject);
        //}

        if (!isCatched)
        {
            Mario mario = collision.gameObject.GetComponent<Mario>();
            if (mario != null)
            {
                isCatched = true;
                mario.CatchItem(type);
                CatchItem();    
            }
        }
    }
    void CatchItem()
    {
        ScoreManager.Instance.SumarPuntos(puntos);
        Destroy(gameObject);

    }



}






