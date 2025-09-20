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
        GamePlayCtrler.Instance.DoWhenGameEnd += DeActiveItem;
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
        if (!gameObject.activeSelf) return;
        theItemSample.ReturnSample(sample);
        sample.transform.SetParent(itemSpawner.transform);
        sample.transform.localPosition = Vector3.zero;
        sample = null;
        itemSpawner.ResetTheItem(this);
        gameObject.SetActive(false);
    }

    void move()
    {
        if (!gameObject.activeSelf) return;
        transform.position += -transform.up * GamePlayCtrler.Instance.speedOfObstacle * Time.fixedDeltaTime;
    }
}
