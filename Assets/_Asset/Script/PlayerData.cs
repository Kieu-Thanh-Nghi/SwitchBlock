using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int diamond = 0;
    GameObject usingBox;
    [SerializeField] Skill magnet, rocket, x2Mutiplier;
    
    [ContextMenu("SetUpSkill")]
    void SetUpSkills()
    {
        string magnetJson = JsonUtility.ToJson(magnet);
        string path = Path.Combine(Application.streamingAssetsPath, "MagnetData.json");
        File.WriteAllText(path, magnetJson);
        string rocketJson = JsonUtility.ToJson(rocket);
        string path1 = Path.Combine(Application.streamingAssetsPath, "RocketData.json");
        File.WriteAllText(path1, rocketJson);
        string x2MutiplierJson = JsonUtility.ToJson(x2Mutiplier);
        string path2 = Path.Combine(Application.streamingAssetsPath, "X2MutiplierData.json");
        File.WriteAllText(path2, x2MutiplierJson);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
