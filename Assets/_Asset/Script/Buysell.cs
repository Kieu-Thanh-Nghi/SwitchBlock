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
}
