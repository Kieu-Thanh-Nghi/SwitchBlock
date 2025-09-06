using UnityEngine;
using System;

[Serializable]
public class X2Multiplier : Skill
{
    public X2Multiplier()
    {
        effDuration = 6;
        effDurationPerLvl = new int[] { 7, 8, 9, 10, 11 };
    }
}
