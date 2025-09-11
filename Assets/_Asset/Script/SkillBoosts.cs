using TMPro;
using UnityEngine;

public class SkillBoosts : MonoBehaviour
{
    [SerializeField] internal int skillIndex;
    [SerializeField] internal TMP_Text useTimes;
    internal SkillUpgradesCtrler upgradesCtrler;

    public void ClickToBoosts(int withWhat)
    {
        upgradesCtrler.DoBoosts(this, withWhat);
    }
}
