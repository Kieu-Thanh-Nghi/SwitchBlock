using System;
using UnityEngine;

public class Buysell : MonoBehaviour
{
    [SerializeField] LoadData data;
    public Action DoWhenDiamondChange;

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

    public bool WatchAD()
    {
        Debug.Log("Da xem quang cao");
        return true;
    }

    public bool PayMoney()
    {
        Debug.Log("Da tra tien");
        return true;
    }
}
