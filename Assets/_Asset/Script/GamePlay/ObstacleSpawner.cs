using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Queue<Obstacle> obstacles = new();
    [SerializeField] Transform midpoint;
    [SerializeField] Obstacle obstaclePrefab;
    [SerializeField] Obstacle changeStateObstaclePrefab;
    ItemSpawner itemSpawner;

    private void Start()
    {
        itemSpawner = GamePlayCtrler.Instance.itemSpawner;
        InvokeRepeating(nameof(spawnAnObstacle), 0, GamePlayCtrler.Instance.ObstacleSpawnTime);
    }

    internal void ToNewState()
    {

    }

    void spawnAnObstacle()
    {

        Obstacle anObstacle;
        if (obstacles.Count == 0) 
        {
            anObstacle = AddMoreObstacle();
        } 
        else
        {
            anObstacle = activeObstacleInQueue();
        }
        if (GamePlayCtrler.Instance.switchState != anObstacle.switchState) anObstacle.SwitchParts();
        anObstacle.transform.position = midpoint.position;
        anObstacle.ArrangeParts();
        itemSpawner.DeActiveSpawnItem();
    }

    Obstacle activeObstacleInQueue()
    {
        if (obstacles.Peek().gameObject.activeSelf) return AddMoreObstacle();
        var anObstacle = obstacles.Dequeue();
        obstacles.Enqueue(anObstacle);
        anObstacle.gameObject.SetActive(true);
        return anObstacle;
    }

    Obstacle AddMoreObstacle()
    {
        Obstacle anObstacle = Instantiate(obstaclePrefab, transform);
        obstacles.Enqueue(anObstacle);
        anObstacle.SetStartPoint(transform);
        return anObstacle;
    }

    internal void SwitchObstacles()
    {
        foreach(var obstacle in obstacles)
        {
            obstacle.SwitchParts();
        }
    }

    private void FixedUpdate()
    {
        foreach (var obstacle in obstacles)
        {
            if (!obstacle.gameObject.activeSelf) continue;
            obstacle.transform.position +=
                -obstacle.transform.up * GamePlayCtrler.Instance.speedOfObstacle * Time.fixedDeltaTime;
        }
    }
}
