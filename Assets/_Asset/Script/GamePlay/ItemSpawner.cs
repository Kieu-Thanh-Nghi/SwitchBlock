using System.Collections.Generic;
using System;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item itemPrefab;
    [SerializeField] List<ItemSample> itemSamples;
    [SerializeField] Transform startPoint, leftPoint, rightPoint;
    [SerializeField] float spawnCountDown;
    [SerializeField] internal bool isActive;
    Queue<Item> itemQueue = new();
    [SerializeField] float plusPointSpawnTime, startingSpawnTime;
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
        totalWeight = 0;
        foreach (var itemSample in itemSamples)
        {
            totalWeight += itemSample.weight;
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(spawnLoop), 0, spawnCountDown);
    }

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

    void spawnLoop()
    {
        if (isActive && spawnAmount > 0)
        {
            if (Time.time - startingSpawnTime < plusPointSpawnTime)
            {
                if (usedSampleIndex < 0) spawnPlusPoint();
            }
            else
            {
                spawnOtherItems();
            }
        }
    }

    private void FixedUpdate()
    {
        ItemMove?.Invoke();
    }

    internal void ActiveSpawnItem()
    {
        isActive = true;
        spawnAmount = maxSpawnAmount;
        startingSpawnTime = Time.time;
        currentTotalWeight = totalWeight;
        usedSampleIndex = -1;
    }

    internal void DeActiveSpawnItem()
    {
        isActive = false;
    }

    void spawnPlusPoint()
    {
        int plusPointSpawnChance = UnityEngine.Random.Range(0, 10);
        Debug.Log(plusPointSpawnChance);
        if(plusPointSpawnChance > 7)
        {
            spawnAnItem(itemSamples[0]);
            usedSampleIndex = 0;
        }
    }

    void spawnOtherItems()
    {
        int randomResult = UnityEngine.Random.Range(0, currentTotalWeight);
        int sum = 0;
        for(int i = 1; i < itemSamples.Count; i++)
        {
            if (usedSampleIndex == i) continue;
            sum += itemSamples[i].weight;
            if (randomResult > sum)
            {
                spawnAnItem(itemSamples[i]);
                currentTotalWeight = currentTotalWeight - itemSamples[i].weight;
                usedSampleIndex = i;
                return;
            }
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
        spawnAmount--;
    }

    internal void ResetTheItem(Item theItem)
    {
        itemQueue.Enqueue(theItem);
    }
}
