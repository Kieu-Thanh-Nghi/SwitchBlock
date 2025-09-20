using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateObstacle : Obstacle
{
    private void Start()
    {
        gamePlayCtrler = GamePlayCtrler.Instance;
        gamePlayCtrler.DoWhenGameEnd += doWhenEndGame;
    }
    private void OnEnable()
    {
        if (GamePlayCtrler.Instance.switchState != switchState) SwitchParts();
        ArrangeParts();
    }

    private void FixedUpdate()
    {
        transform.position += -transform.up * gamePlayCtrler.speedOfObstacle * Time.fixedDeltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lastpoint"))
        {
            gameObject.SetActive(false);
        }
    }

    void doWhenEndGame() => gameObject.SetActive(false);

    private void OnDisable()
    {
        transform.localPosition = new Vector2(transform.localPosition.x, 0);
    }
}
