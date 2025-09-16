using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<Obstacle> obstacles;
    [SerializeField] Obstacle obstaclePrefab;

    void AddMoreObstacle()
    {
        Obstacle anObstacle = Instantiate(obstaclePrefab);
        obstacles.Add(anObstacle);
        anObstacle.SetStartPoint(transform);
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
            if (obstacle.isStop) continue;
            obstacle.transform.position +=
                -obstacle.transform.up * GamePlayCtrler.Instance.speedOfObstacle * Time.fixedDeltaTime;
        }
    }
}
