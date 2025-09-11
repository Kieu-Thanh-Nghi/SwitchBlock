using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SkillUpgrade : MonoBehaviour
{
    [SerializeField] internal int skillIndex;
    [SerializeField] internal TMP_Text levelText, time;
    [SerializeField] internal Image[] upgradeProcesses;
    [SerializeField] internal Color color;
    internal SkillUpgradesCtrler upgradesCtrler;

    public void ClickToUpgrade(int withWhat)
    {
        upgradesCtrler.DoUpgrade(this, withWhat);
    }
}
