using UnityEngine;

public class Magnet : Skill
{
    [SerializeField] protected new int effDuration = 7;
    [SerializeField] protected new int[] effDurationPerLvl = { 8, 9, 10, 11, 12 };
    protected new string jsonFile = "MagnetData.json";
}
