using UnityEngine;
using System;

[Serializable]
public class Magnet : Skill
{
    [SerializeField] internal override int effDuration => 7;
    [SerializeField] internal override int[] effDurationPerLvl => new int[] { 8, 9, 10, 11, 12 };
}
