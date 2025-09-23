using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    [SerializeField] protected int itemIdex;
    protected Item item;
    protected GamePlayCtrler gamePlayCtrler;
    internal void SetUp(Item item)
    {
        this.item = item;
        gamePlayCtrler = GamePlayCtrler.Instance;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lastpoint"))
        {
            ColloderWithLastPoint();
        }
        else if (collision.CompareTag("Player"))
        {
            ColloderWithPlayer();
        }
    }

    protected virtual void ColloderWithLastPoint()
    {
        item.DeActiveItem();
    }    
    
    protected virtual void ColloderWithPlayer()
    {
        gamePlayCtrler.DoItemEff(itemIdex);
        item.DeActiveItem();
    }
}
