using System;
using UnityEngine;

public class Buysell : MonoBehaviour
{
    [SerializeField] LoadData data;
    public Action DoWhenDiamondChange;
    public Action DoAfterAD;
    public Action DoAfterPayMoney;
    int[] skinPrices = { 0,0,0,0,15000,15000,30000,30000,30000,30000,
    91000,91000,91000,91000,91000,91000,91000};

    public int currentDiamond()
    {
        return data.playerData.diamond;
    }
    public void AddDiamonds(int diamonds)
    {
        data.playerData.diamond += diamonds;
        data.SavePlayerData();
        DoWhenDiamondChange?.Invoke();
    }
    public void BuyDiamonds()
    {
        Debug.Log("having more diamonds");
        AddDiamonds(100);
    }
    public bool PayWithDiamonds(int diamondsQuantity)
    {
        if (data.playerData.diamond < diamondsQuantity) return false;
        AddDiamonds(-diamondsQuantity);
        return true;
    }
    public void ShowAchivement()
    {
        Debug.Log("showing achivement");
    }    
    
    public void ShowLeaderBoard()
    {
        Debug.Log("showing LeaderBoard");
    }

    public void RemoveAdd()
    {
        Debug.Log("removing add");
    }

    public void WatchAD(bool refressAfterDone = false)
    {
        Debug.Log("Da xem quang cao");
        DoAfterAD?.Invoke();
        if (refressAfterDone) DoAfterAD = null;
    }

    public void PayMoney(int cost, bool refressAfterDone = false)
    {
        Debug.Log("Da tra tien: " + cost + " dong");
        DoAfterPayMoney?.Invoke();
        if (refressAfterDone) DoAfterPayMoney = null;
    }

    public void PayMoneyForSkin(Skin theSkin, bool refressAfterDone = false)
    {
        PayMoney(skinPrices[theSkin.index], refressAfterDone);
    }
}
