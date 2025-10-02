using UnityEngine;

public class AdsManager : MonoBehaviour
{
    [SerializeField] internal AdsInitializer adsInitializer;
    [SerializeField] internal InterstitialAd interstitialAd;
    [SerializeField] internal RewardedAds rewardedAds;

    public static AdsManager Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        interstitialAd.LoadAd();
        rewardedAds.LoadAd();
    }
}
