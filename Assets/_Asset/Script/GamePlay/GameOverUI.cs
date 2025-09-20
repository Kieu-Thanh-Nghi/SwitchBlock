using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Buysell buysell;
    [SerializeField] int diamondForRevive;

    public void PayDiamondToRevive()
    {
        if (buysell.PayWithDiamonds(diamondForRevive))
        {
            GamePlayCtrler.Instance.RePlay();
        }
    }
}
