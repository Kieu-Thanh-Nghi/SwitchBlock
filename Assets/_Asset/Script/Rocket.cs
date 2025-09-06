using UnityEngine;
using System;

[Serializable]
public class Rocket : Skill
{
    public Rocket()
    {
        effDuration = 4;
        effDurationPerLvl = new int[] { 5, 6, 7, 8, 9 };
    }
}
