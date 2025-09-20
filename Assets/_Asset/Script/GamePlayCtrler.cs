using System;
using UnityEngine;

public class GamePlayCtrler : MonoBehaviour
{
    [SerializeField] StatisticCounting statisticCounting;
    [SerializeField] internal bool switchState = false;
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] internal Color switchStateBlack, switchStateWhite;
    [SerializeField] internal Player player;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] internal ObstacleSpawner obstacleSpawner;
    [SerializeField] internal ItemSpawner itemSpawner;
    [SerializeField] int ObstacleMustPassForNextState = 27;
    [SerializeField] float baseObstacleSpeed;
    [SerializeField] float speedBonusEachState = 1;
    [SerializeField] GameObject ReviveUI, EndGameUI, GamePlayUI;
    public float speedOfObstacle;
    float speedTemp;
    int ObstacleHasPass = 0, totalObstacleHasPass = 0;
    public float ObstacleSpawnTime = 1;
    int state = 1;
    bool isEnd = false;
    internal Action DoWhenGameEnd;

    public static GamePlayCtrler Instance { get; private set; }

    private void Awake()
    {
        speedTemp = baseObstacleSpeed;
        Debug.Log(speedTemp);
        Instance = this;
        SetDefaultSpeed();
    }

    internal void EndTheGame()
    {
        Debug.Log(speedTemp);
        isEnd = true;
        Debug.Log("endgame");
        GamePlayUI.SetActive(false);
        if (totalObstacleHasPass > 0)
        {
            deActiveSpawners();
            ReviveUI.SetActive(true);
        }
        else
        {
            DoWhenGameEnd?.Invoke();
            deActiveSpawners();
            EndGameUI.SetActive(true);
        }
    }

    void deActiveSpawners()
    {
        statisticCounting.enabled = false;
        playerMovement.enabled = false;
        itemSpawner.isActive = false;
        obstacleSpawner.DeActiveSpawner();
        speedOfObstacle = 0;
        isEnd = true;
    }

    public void RePlay()
    {
        statisticCounting.enabled = true;
        playerMovement.enabled = true;
        obstacleSpawner.ActiveSpawnObstacle();
        speedOfObstacle = speedTemp;
        ObstacleHasPass = 0;
        itemSpawner.isActive = true;
        isEnd = false;
    }

    public void Revive()
    {
        DoWhenGameEnd?.Invoke();
        RePlay();
    }

    public void PlayAgain()
    {
        statisticCounting.RestartPoint();
        RePlay();
    }

    public void SkipRevive() => DoWhenGameEnd?.Invoke();

    internal void PassingObstacleUpdate()
    {
        totalObstacleHasPass++;
        ObstacleHasPass++;
        if(ObstacleHasPass == ObstacleMustPassForNextState)
        {
            obstacleSpawner.ToNewState();
            itemSpawner.DeActiveSpawnItem();
            itemSpawner.isActive = false;
        }
    }

    internal void nextState()
    {
        if (isEnd) return;
        Debug.Log("Ss");
        state++;
        ObstacleHasPass = 0;
        speedOfObstacle += speedBonusEachState;
        speedTemp = speedOfObstacle;
        obstacleSpawner.ActiveSpawnObstacle();
        itemSpawner.isActive = true;
    }

    internal void SetPlayer(Player thePlayer)
    {
        player = thePlayer;
        playerMovement.player = thePlayer;
    }
    public void SetDefaultSpeed()
    {
        speedOfObstacle = baseObstacleSpeed;
    }

    internal void DoItemEff(int itemIndex)
    {
        if(itemIndex == 2)
        {
            UseSwitchState();
        }
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
