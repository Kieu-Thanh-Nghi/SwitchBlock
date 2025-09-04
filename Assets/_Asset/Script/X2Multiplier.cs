using UnityEngine;

public class X2Multiplier : Skill
{
    [SerializeField] protected new int effDuration = 6;
    [SerializeField] protected new int[] effDurationPerLvl = { 7, 8, 9, 10, 11 };
    protected new string jsonFile = "X2MultiplierData.json";
}
