using UnityEngine;
using System;

[Serializable]
public class X2Multiplier : Skill
{
    [SerializeField] internal override int effDuration => 6;
    [SerializeField] internal override int[] effDurationPerLvl => new int[] { 7, 8, 9, 10, 11 };
}
