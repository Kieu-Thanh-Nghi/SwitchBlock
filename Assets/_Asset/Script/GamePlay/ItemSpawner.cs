using System.Collections.Generic;
using System;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item itemPrefab;
    [SerializeField] int noOtherItemPercent;
    [SerializeField] List<ItemSample> itemSamples;
    [SerializeField] Transform startPoint, leftPoint, rightPoint;
    [SerializeField] float spawnCountDown;
    [SerializeField] internal bool isActive;
    Queue<Item> itemQueue = new();
    [SerializeField] float plusPointSpawnTime, otherItemSpawnTime = 0;
    int maxSpawnAmount = 2, spawnAmount;
    int totalWeight, currentTotalWeight;
    int usedSampleIndex = -1;
    internal Action ItemMove;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            ActiveSpawnItem();
        }
    }

    private void Awake()
    {
        plusPointSpawnTime = GamePlayCtrler.Instance.ObstacleSpawnTime / 3f;
        totalWeight = noOtherItemPercent;
        foreach (var itemSample in itemSamples)
        {
            totalWeight += itemSample.weight;
        }
    }

    //private void Start()
    //{
    //    InvokeRepeating(nameof(spawnLoop), 0, spawnCountDown);
    //}

    //private void Update()
    //{
    //    if (isActive && spawnAmount > 0)
    //    {
    //        if (Time.time - startingSpawnTime < plusPointSpawnTime)
    //        {
    //            if(usedSampleIndex < 0) spawnPlusPoint();
    //        }
    //        else
    //        {
    //            if (spawnAmount < maxSpawnAmount) Invoke(nameof(spawnOtherItems), spawnCountDown);
    //            else spawnOtherItems();
    //        }
    //    }
    //}

    //void spawnLoop()
    //{
    //    if (isActive && spawnAmount > 0)
    //    {
    //        if (Time.time - startingSpawnTime < plusPointSpawnTime)
    //        {
    //            if (usedSampleIndex < 0) spawnPlusPoint();
    //        }
    //        else
    //        {
    //            spawnOtherItems();
    //        }
    //    }
    //}

    private void FixedUpdate()
    {
        ItemMove?.Invoke();
    }

    internal void ActiveSpawnItem()
    {
        isActive = true;
        spawnAmount = maxSpawnAmount;
        currentTotalWeight = totalWeight;
        otherItemSpawnTime = plusPointSpawnTime;
        usedSampleIndex = -1;
        int plusPointSpawnChance = UnityEngine.Random.Range(0, 10);
        if (plusPointSpawnChance > 5)
        {
            spawnAmount--;
            Invoke(nameof(spawnPlusPoint), UnityEngine.Random.Range(0f, plusPointSpawnTime));
        }
        for (int i = 0; i < spawnAmount; i++)
        {
            float bonusTime = 0;
            if (i >= 1) bonusTime = spawnCountDown;
            otherItemSpawnTime = UnityEngine.Random.Range(otherItemSpawnTime + bonusTime,
                GamePlayCtrler.Instance.ObstacleSpawnTime - plusPointSpawnTime);
            Invoke(nameof(spawnOtherItems), otherItemSpawnTime);
        }
    }

    internal void DeActiveSpawnItem()
    {
        isActive = false;
        CancelInvoke();
    }

    void spawnPlusPoint()
    {
        usedSampleIndex = 0;
        spawnAnItem(itemSamples[0]);
    }

    void spawnOtherItems()
    {
        int randomResult = UnityEngine.Random.Range(0, currentTotalWeight);
        if (randomResult < noOtherItemPercent) return;
        int sum = noOtherItemPercent;
        for(int i = 1; i < itemSamples.Count; i++)
        {
            if (usedSampleIndex == i) continue;
            if (randomResult > sum && randomResult < sum + itemSamples[i].weight)
            {
                usedSampleIndex = i;
                spawnAnItem(itemSamples[i]);
                currentTotalWeight = currentTotalWeight - itemSamples[i].weight;
                return;
            }
            sum += itemSamples[i].weight;
        }
    }

    void spawnAnItem(ItemSample itemSample)
    {
        Item anItem;
        if (!(itemQueue.Count > 0))
        {
            anItem = Instantiate(itemPrefab, transform);
            anItem.SetUpItemSpawner(this);
        }
        else
        {
            anItem = itemQueue.Dequeue();
            anItem.gameObject.SetActive(true);
        }
        float newX = UnityEngine.Random.Range(leftPoint.localPosition.x, rightPoint.localPosition.x);
        anItem.transform.localPosition = new Vector2(newX, 0);
        anItem.ItemSetUp(itemSample);
    }

    internal void ResetTheItem(Item theItem)
    {
        itemQueue.Enqueue(theItem);
    }
}
