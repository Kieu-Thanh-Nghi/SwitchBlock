using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] string leaderboardID = "CgkI1cabzr0fEAIQAg";

    private void Start()
    {
        PlayGamesPlatform.Activate();
        ReportScore(LoadData.Instance.statistics.HighScore);
        LoadLeaderboard();
        LoadData.Instance.SaveStatisticsData();
    }

    public void ReportScore(long score)
    {
        if(Social.localUser.authenticated) Social.ReportScore(score, leaderboardID, success => Debug.Log(success ? "success" : "fail"));
        else Debug.LogWarning("Chưa đăng nhập, không thể gửi điểm.");
    }

    public void LoadLeaderboard()
    {
        PlayGamesPlatform.Instance.LoadScores(
            leaderboardID,
            LeaderboardStart.TopScores,
            3,
            LeaderboardCollection.Public,
            LeaderboardTimeSpan.AllTime,
            (data) =>
            {
                if(data.Status == ResponseStatus.Success)
                {
                    foreach (var score in data.Scores)
                    {
                        LoadData.Instance.statistics.Top3Score.Add((int)score.value);
                    }
                }
            });
    }
    public void ShowLeaderboardUI()
    {
        if (Social.localUser.authenticated) PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboardID);
        else Debug.LogWarning("Chưa đăng nhập, không thể mở Leaderboard UI.");
    }
}
