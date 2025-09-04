using UnityEngine;
using System;

[Serializable]
public class Rocket : Skill
{
    [SerializeField] internal override int effDuration => 4;
    [SerializeField] internal override int[] effDurationPerLvl => new int[] { 5, 6, 7, 8, 9 };
}
