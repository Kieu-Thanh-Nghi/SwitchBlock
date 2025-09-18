using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    [SerializeField] int itemIdex;
    Item item;
    GamePlayCtrler gamePlayCtrler;
    internal void SetUp(Item item)
    {
        this.item = item;
        gamePlayCtrler = GamePlayCtrler.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lastpoint"))
        {
            item.DeActiveItem();
        }
        if (collision.CompareTag("Player"))
        {
            gamePlayCtrler.DoItemEff(itemIdex);
            item.DeActiveItem();
        }
    }
}
