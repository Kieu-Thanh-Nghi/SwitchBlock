using UnityEngine;
using System;

[Serializable]
public class Magnet : Skill
{
    public Magnet()
    {
        effDuration = 7;
        effDurationPerLvl = new int[] { 8, 9, 10, 11, 12 };
    }
}
