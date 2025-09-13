using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrler : MonoBehaviour
{
    [SerializeField] bool switchState = false;
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] Color swithStateBlack, switchStateWhite;

    [ContextMenu("switch test")]
    internal void UseSwitchState()
    {
        switchState = !switchState;
        if (switchState)
        {
            backGround.color = switchStateWhite;
        }
        else
        {
            backGround.color = swithStateBlack;
        }
        Player.Instance.SwitchEff(switchState);
    }
}
