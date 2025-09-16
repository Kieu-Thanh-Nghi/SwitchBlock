using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item itemPrefab;
    [SerializeField] List<ItemSample> itemSamples;
    Queue<Item> itemQueue;
    Item nextItem;
    internal bool isActive;
    float plusPointSpawnTime;
    float startingSpawnTime;
    int maxSpawnAmount = 2;
    int spawnAmount;
    int remainItems = 0;
    int totalWeight;
    int currentTotalWeight;
    int usedSampleIndex = -1;

    private void Awake()
    {
        plusPointSpawnTime = GamePlayCtrler.Instance.ObstacleSpawnTime / 3f;
        totalWeight = 0;
        foreach (var itemSample in itemSamples)
        {
            totalWeight += itemSample.weight;
        }
    }

    private void Update()
    {
        if (isActive && spawnAmount > 0)
        {
            if (Time.time - startingSpawnTime < plusPointSpawnTime)
            {
                spawnPlusPoint();
            }
            else
            {
                spawnOtherItems();
            }
            spawnAmount--;
        }
        moveItems();
    }

    internal void ActiveSpawnItem()
    {
        isActive = true;
        spawnAmount = maxSpawnAmount;
        startingSpawnTime = Time.time;
        currentTotalWeight = totalWeight;
    }

    void spawnPlusPoint()
    {
        int plusPointSpawnChance = Random.Range(0, 10);
        if(plusPointSpawnChance > 6)
        {
            spawnAnItem(itemSamples[0]);
        }
    }

    void spawnOtherItems()
    {
        int randomResult = Random.Range(0, currentTotalWeight);
        int sum = 0;
        for(int i = 0; i < itemSamples.Count; i++)
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
        if (!(remainItems > 0))
        {
            Item anItem = Instantiate(itemPrefab);
            anItem.ItemSetUp(itemSample);
            itemQueue.Enqueue(anItem);
        }
        else
        {
            nextItem.ItemSetUp(itemSample);
            nextItem.gameObject.SetActive(true);
            remainItems--;
        }
    }

    internal void ResetTheItem(Item theItem)
    {
        theItem.gameObject.SetActive(false);
        if(remainItems == 0)
        {
            nextItem = theItem;
        }
        remainItems++;
    }

    void moveItems()
    {

    }
}
