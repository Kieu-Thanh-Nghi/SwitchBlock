using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrler : MonoBehaviour
{
    [SerializeField] bool switchState = false;
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] internal Color switchStateBlack, switchStateWhite;
    [SerializeField] float baseObstacleSpeed;
    [SerializeField] Player player;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    public float speedOfObstacle;

    public static GamePlayCtrler Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        SetDefaultSpeed();
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
        switchBackGround();
        player.SwitchEff(switchState);
        obstacleSpawner.SwitchObstacles();
    }

    void switchBackGround()
    {
        switchState = !switchState;
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
