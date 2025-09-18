using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemSample theItemSample;
    ItemSpawner itemSpawner;
    Sample sample;

    internal void SetUpItemSpawner(ItemSpawner itemSpawner)
    {
        this.itemSpawner = itemSpawner;
        itemSpawner.ItemMove += move;
    }

    internal void ItemSetUp(ItemSample itemSample)
    {
        theItemSample = itemSample;
        sample = theItemSample.GetSample();
        sample.SetUp(this);
        sample.transform.SetParent(transform, false);
        sample.transform.localPosition = Vector3.zero;
    }

    internal void DeActiveItem()
    {
        sample.transform.SetParent(itemSpawner.transform, false);
        sample.transform.localPosition = Vector3.zero;
        itemSpawner.ResetTheItem(this);
        theItemSample.ReturnSample(sample);
        gameObject.SetActive(false);
    }

    void move()
    {
        if (!gameObject.activeSelf) return;
        transform.position += -transform.up * GamePlayCtrler.Instance.speedOfObstacle * Time.fixedDeltaTime;
    }
}
