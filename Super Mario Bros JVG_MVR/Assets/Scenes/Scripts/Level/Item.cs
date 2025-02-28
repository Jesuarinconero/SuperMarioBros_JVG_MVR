using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Mario ha tocado el item");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Mario>().CatchItem(type);
            Destroy(gameObject);
        }
    }


}

public enum ItemType { MagicMushroom, FireFlower, Coin, Life, Star}
