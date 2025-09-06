using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buysell : MonoBehaviour
{
    [SerializeField] LoadData data;
    public void AddDiamonds(int diamonds)
    {
        data.playerData.diamond += diamonds;
        data.SavePlayerData();
    }
    public void BuyDiamonds()
    {
        Debug.Log("having more diamonds");
        AddDiamonds(100);
    }
}
