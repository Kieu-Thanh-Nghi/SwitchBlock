using UnityEngine;

public class Rocket : Skill
{
    [SerializeField] protected new int effDuration = 4;
    [SerializeField] protected new int[] effDurationPerLvl = { 5, 6, 7, 8, 9 };
    protected new string jsonFile = "RocketData.json";
}
