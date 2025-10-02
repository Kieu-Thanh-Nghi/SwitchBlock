using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Events;

public class Buysell : MonoBehaviour
{
    [SerializeField] LoadData data;
    [SerializeField] UnityEvent DoEventWhenDiamondChange;
    public Action DoWhenDiamondChange;
    public Action DoAfterAD;
    public Action DoAfterPayMoney;

    public int currentDiamond()
    {
        return data.playerData.diamond;
    }
    public void AddDiamonds(int diamonds, bool hasSaved = true)
    {
        data.playerData.diamond += diamonds;
        if(hasSaved) data.SavePlayerData();
        DoWhenDiamondChange?.Invoke();
        DoEventWhenDiamondChange?.Invoke();
    }
    public void BuyDiamonds(string productID)
    {
        if(productID == "plus2000diamonds")
        {
            DoAfterPayMoney += () => AddDiamonds(2000);
        }
        else if(productID == "plus500diamonds")
        {
            DoAfterPayMoney += () => AddDiamonds(500);
        }
        CodelessIAPStoreListener.Instance.InitiatePurchase(productID);
    }

    public bool PayWithDiamonds(int diamondsQuantity)
    {
        if (data.playerData.diamond < diamondsQuantity)
        {
            BuyDiamonds("plus500diamonds");
            return false;
        }
        AddDiamonds(-diamondsQuantity);
        return true;
    }

    public void RemoveAdd()
    {
        DoAfterPayMoney += doWhenRemoveAD;
        CodelessIAPStoreListener.Instance.InitiatePurchase("noad");
    }

    void doWhenRemoveAD()
    {
        data.playerData.isNoAd = true;
        data.SavePlayerData();
    }
    public void WatchAD(bool refressAfterDone = false, int AdType = 0)
    {
        if (AdType == 0)
        {
            AdsManager.Instance.rewardedAds.DoWhenRewardAdComplete = DoAfterAD;
            AdsManager.Instance.rewardedAds.ShowAd();
        }
        else if(AdType == 1){
            if (data.playerData.isNoAd)
            {
                DoAfterAD?.Invoke();
            }
            else
            {
                AdsManager.Instance.interstitialAd.DoWhenInterstitialAdComplete = DoAfterAD;
                AdsManager.Instance.interstitialAd.ShowAd();
            }
        }

        if (refressAfterDone) DoAfterAD = null;
    }

    public void DoAfterCompletedPurchage(bool refressAfterDone = false)
    {
        DoAfterPayMoney?.Invoke();
        if (refressAfterDone) DoAfterPayMoney = null;
    }

    public void DoAfterPurchageFail()
    {
        DoAfterPayMoney = null;
    }

    public void PayMoneyForSkin(Skin theSkin)
    {
        CodelessIAPStoreListener.Instance.InitiatePurchase(theSkin.productID);
    }
}
