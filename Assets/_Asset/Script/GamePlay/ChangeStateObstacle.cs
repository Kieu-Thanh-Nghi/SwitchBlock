using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateObstacle : Obstacle
{
    private void OnEnable()
    {
        n = parts.Length;
        gamePlayCtrler = GamePlayCtrler.Instance;
        if (gamePlayCtrler.switchState != switchState) SwitchParts();
        ArrangeParts();
    }

    private void FixedUpdate()
    {
        transform.position += -transform.up * gamePlayCtrler.speedOfObstacle * Time.fixedDeltaTime;
    }
}
