using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class AchivementManager : MonoBehaviour
{
    public static AchivementManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void ShowAchivementUI()
    {
        Social.ShowAchievementsUI();
    }
    public void UnlockCurriusCatAchivement()
    {
        Social.ReportProgress(GPGSIds.achievement_currious_cat, 100.0f, (bool success) =>
        {
            if (success) Debug.Log("currious_cat Unlocked!");
            else Debug.Log("Failed to unlock Currius Cat");
        });
    }

    public void DoDeathsBestFriendAchivement()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(
            GPGSIds.achievement_deaths_best_friend, 1, (bool success) =>
            {
                if (success) Debug.Log("deaths_best_friend Unlocked!");
                else Debug.Log("Failed to unlock deaths_best_friend");
            });
    }

    public void DoMagneticAchivement()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(
            GPGSIds.achievement_magnetic_i, 1, (bool success) =>
            {
                if (success) Debug.Log("achievement_magnetic_i Unlocked!");
                else Debug.Log("Failed to unlock achievement_magnetic_i");
            });
    }

    public void DoVeteranAchivement()
    {
        PlayGamesPlatform.Instance.IncrementAchievement(
            GPGSIds.achievement_veteran_i, 1, (bool success) =>
            {
                if (success) Debug.Log("achievement_veteran_i Unlocked!");
                else Debug.Log("Failed to unlock achievement_veteran_i");
            });
    }

    public void DoSurviorAchivement(float seconds)
    {
        if(seconds - 5*60 >= 0)
        {
            Social.ReportProgress(GPGSIds.achievement_survivor_i, 100.0f, (bool success) =>
            {
                if (success) Debug.Log("achievement_survivor_i Unlocked!");
                else Debug.Log("Failed to unlock achievement_survivor_i");
            });
        }
    }
}
