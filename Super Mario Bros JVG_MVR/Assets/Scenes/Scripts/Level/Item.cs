using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { MagicMushroom, FireFlower, Coin, Life, Star }
public class Item : MonoBehaviour
{
    public ItemType type;

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Mario>().CatchItem(type);
            Destroy(gameObject);

        }
    }


}






