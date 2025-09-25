using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GamePlayCtrler : MonoBehaviour
{
    [SerializeField] Buysell buysell;
    [SerializeField] internal LoadData data;
    [SerializeField] StatisticCounting statisticCounting;
    [SerializeField] internal SoundStore sound;

    [SerializeField] internal bool switchState = false;
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] internal Color switchStateBlack, switchStateWhite;
    [SerializeField] internal Player player;
    [SerializeField] ParticleSystem startGameParticleSystem;
    [SerializeField] PlayerMovement playerMovement;
    WaitForSeconds waitStartGame;


    [SerializeField] internal ObstacleSpawner obstacleSpawner;
    [SerializeField] internal ItemSpawner itemSpawner;

    [SerializeField] int numberOfDiamondCanAdd = 1;
    [SerializeField] int bonusPointWhenTakeItem = 100;
    [SerializeField] int bonusPointWhenTakeDiamonds = 50;
    [SerializeField] float rocketCountSpeedUp = 2;
    float rocketSpeedTemp;

    [SerializeField] int ObstacleMustPassForNextState = 27;
    [SerializeField] float baseObstacleSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float speedBonusEachState = 1;
    bool isNextState = true;

    [SerializeField] GameObject ReviveUI, EndGameUI;
    [SerializeField] GamePlayUICtrler GamePlayUI;
    [SerializeField] CountDownUI countDown;

    public float speedOfObstacle;
    float speedTemp;
    int ObstacleHasPass = 0, totalObstacleHasPass = 0;
    public float ObstacleSpawnTime = 1;
    int state = 1;
    bool isEnd = false;
    WaitForSeconds EndTimeDelay = new WaitForSeconds(0.75f);
    internal Action DoWhenGameEnd;

    public static GamePlayCtrler Instance { get; private set; }

    private void Awake()
    {
        waitStartGame = new WaitForSeconds(1f);
        speedTemp = baseObstacleSpeed;
        Instance = this;
        SetDefaultSpeed();
    }

    //private void Start()
    //{
    //    StartCoroutine(StartGamePlay());
    //}

    IEnumerator StartGamePlay(bool isRivive = false)
    {
        player.transform.position = player.PlayerStartPos;
        var particleMain = startGameParticleSystem.main;
        particleMain.startColor = player.GetParticleColor();
        startGameParticleSystem.Play();
        yield return waitStartGame;
        player.gameObject.SetActive(true);
        if (isRivive) player.StartBlink();
        yield return waitStartGame;
        obstacleSpawner.ActiveSpawnObstacle();
    }

    internal void EndTheGame()
    {
        if (player.isImunity) return;
        player.Die();
        sound.PlayGameSound(false);
        sound.PlayDieSound();
        isEnd = true;
        GamePlayUI.gameObject.SetActive(false);
        if (totalObstacleHasPass > 0)
        {
            deActiveSpawners();
            StartCoroutine(turnOnGameOverUI(ReviveUI));
        }
        else
        {
            DoWhenGameEnd?.Invoke();
            deActiveSpawners();
            StartCoroutine(turnOnGameOverUI(EndGameUI));
        }
    }

    IEnumerator turnOnGameOverUI(GameObject UI)
    {
        yield return EndTimeDelay;
        UI.SetActive(true);
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

    public void RePlay(bool isRivive = false)
    {
        statisticCounting.enabled = true;
        playerMovement.enabled = true;
        speedOfObstacle = speedTemp;
        ObstacleHasPass = 0;
        itemSpawner.isActive = true;
        isEnd = false;
        sound.PlayGameSound(true);
        StartCoroutine(StartGamePlay(isRivive));
    }

    public void Revive()
    {
        DoWhenGameEnd?.Invoke();
        RePlay(true);
    }

    public void PlayAgain()
    {
        data.SavePlayerData();
        statisticCounting.SaveStatistic();
        statisticCounting.RestartPoint();
        RePlay();
    }

    internal void OutOfGamePlay()
    {
        data.SavePlayerData();
        statisticCounting.SaveStatistic();
    }

    public void SkipRevive() => DoWhenGameEnd?.Invoke();

    internal void PassingObstacleUpdate()
    {
        if (!isNextState) return;
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
        playerMovement.enabled = true;
        statisticCounting.RestartPoint();
        StartCoroutine(StartGamePlay());
    }
    public void SetDefaultSpeed()
    {
        speedOfObstacle = baseObstacleSpeed;
    }

    public void DoItemEff(int itemIndex)
    {
        switch (itemIndex)
        {
            case 0:
                statisticCounting.BonusPoint(bonusPointWhenTakeItem);
                sound.PlayPlusPoint();
                break;
            case 1:
                statisticCounting.BonusPoint(bonusPointWhenTakeDiamonds);
                buysell.AddDiamonds(numberOfDiamondCanAdd,false);
                sound.PlayPlusDiamond();
                break;
            case 2:
                UseSwitchState();
                sound.PlaySwitchState();
                break;
            case 3:
                sound.PlayExplode();
                Invoke(nameof(EndTheGame), 0.15f);
                break;
            case 4:
                float MagnetCountTime = data.playerData.magnet.effDuration;
                if (!countDown.isMagnetCounting(MagnetCountTime))
                    StartCoroutine(GotMagnet(MagnetCountTime));
                break;
            case 5:
                float rocketCountTime = data.playerData.rocket.effDuration;
                if (!countDown.isRocketCounting(rocketCountTime))
                    StartCoroutine(GotRocket(rocketCountTime));
                break;
            case 6:
                float x2CountTime = data.playerData.x2Mutiplier.effDuration;
                if (!countDown.is2XCounting(x2CountTime)) 
                    StartCoroutine(Got2X(x2CountTime));
                break;
        }
    }

    IEnumerator Got2X(float seconds)
    {
        numberOfDiamondCanAdd *= 2;
        bonusPointWhenTakeItem *= 2;
        statisticCounting.plusPointEachTime *= 2;
        sound.PlayX2AndMagnetSound(true);
        yield return StartCoroutine(countDown.doWhenGot2X(seconds));
        numberOfDiamondCanAdd /= 2;
        bonusPointWhenTakeItem /= 2;
        statisticCounting.plusPointEachTime /= 2;
        sound.PlayX2AndMagnetSound(false);
    }    
    
    IEnumerator GotRocket(float seconds)
    {
        statisticCounting.secondToAddPoint /= rocketCountSpeedUp;
        rocketSpeedTemp = speedOfObstacle; speedOfObstacle = maxSpeed;
        isNextState = false;
        player.isImunity = true;
        sound.PlayRocketSound();
        yield return StartCoroutine(countDown.doWhenGotRocket(seconds));
        statisticCounting.secondToAddPoint *= rocketCountSpeedUp;
        speedOfObstacle = rocketSpeedTemp;
        isNextState = true;
        player.isImunity = false;
    }    
    
    IEnumerator GotMagnet(float seconds)
    {
        player.magnet.SetActive(true);
        sound.PlayX2AndMagnetSound(true);
        yield return StartCoroutine(countDown.doWhenGotMagnet(seconds));
        player.magnet.SetActive(false);
        sound.PlayX2AndMagnetSound(false);
    }

    [ContextMenu("switch test")]
    internal void UseSwitchState()
    {
        switchState = !switchState;
        switchBackGround();
        player.SwitchEff(switchState);
        obstacleSpawner.SwitchObstacles();
        GamePlayUI.SwitchUIColor(!switchState);
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

    public void BackToMenu()
    {
        Destroy(player.gameObject);
        OutOfGamePlay();
        SceneManager.LoadScene(0);
    }
}
