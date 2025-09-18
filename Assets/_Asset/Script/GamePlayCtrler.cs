using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrler : MonoBehaviour
{
    [SerializeField] internal bool switchState = false;
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] internal Color switchStateBlack, switchStateWhite;
    [SerializeField] float baseObstacleSpeed;
    [SerializeField] Player player;
    [SerializeField] internal ObstacleSpawner obstacleSpawner;
    [SerializeField] internal ItemSpawner itemSpawner;
    [SerializeField] internal float secondToAddPoint = 0.5f;
    [SerializeField] float speedBonusEachState = 1;
    [SerializeField] int ObstacleMustPassForNextState = 27;
    int ObstacleHasPass = 0;
    public float speedOfObstacle;
    public float ObstacleSpawnTime = 1;
    internal int PlayerPoint = 0;
    int state = 1;

    public static GamePlayCtrler Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        SetDefaultSpeed();
    }

    internal void PassingObstacleUpdate()
    {
        ObstacleHasPass++;
        Debug.Log(ObstacleHasPass);
        if(ObstacleHasPass > ObstacleMustPassForNextState)
        {
            ObstacleHasPass = 0;
            nextState();
        }
    }

    void nextState()
    {
        state++;
        speedOfObstacle += speedBonusEachState;
    }

    internal void SetPlayer(Player thePlayer)
    {
        player = thePlayer;
    }
    public void SetDefaultSpeed()
    {
        speedOfObstacle = baseObstacleSpeed;
    }

    [ContextMenu("switch test")]
    internal void UseSwitchState()
    {
        switchState = !switchState;
        switchBackGround();
        player.SwitchEff(switchState);
        obstacleSpawner.SwitchObstacles();
    }

    void switchBackGround()
    {
        if (switchState)
        {
            backGround.color = switchStateWhite;
        }
        else
        {
            backGround.color = switchStateBlack;
        }
    }
}
