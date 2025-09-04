using System.IO;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    string path = Path.Combine(Application.streamingAssetsPath, "Data.json");
    [SerializeField] PlayerData playerData = new();

    [ContextMenu("SetUpSkill")]
    void SetUpSkills()
    {
        string dataJson = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, dataJson);
    }

    [ContextMenu("Config")]
    public virtual void Config()
    {
        string dataJson = File.ReadAllText(path);
        PlayerData pd = JsonUtility.FromJson<PlayerData>(dataJson);
        playerData.magnet = pd.magnet;
        playerData.rocket = pd.rocket;
        playerData.x2Mutiplier = pd.x2Mutiplier;
    }
    // Start is called before the first frame update
    void Start()
    {
        Config();
    }
}
