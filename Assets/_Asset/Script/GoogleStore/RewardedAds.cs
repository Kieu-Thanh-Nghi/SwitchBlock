using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId;
    internal Action DoWhenRewardAdComplete;
    private void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ?
            _iOSAdUnitId :
            _androidAdUnitId;
    }

    public void LoadAd()
    {       
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        Debug.Log("Show RewardAd");
        Advertisement.Show(_adUnitId, this);
        LoadAd();
    }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    { }

    public void OnUnityAdsShowStart(string placementId)
    {
      
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        DoWhenRewardAdComplete?.Invoke();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Loaded RewardAd");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        
    }
}
