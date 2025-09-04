using System.IO;
using UnityEngine;
using System;

[Serializable]
public class Skill
{
    [SerializeField] internal int Quantity = 0;
    [SerializeField] internal int level = 1;
    [SerializeField] internal int diamondForOneUse = 150;
    [SerializeField] internal virtual int effDuration => 0;
    [SerializeField] internal virtual int[] effDurationPerLvl => null;
    [SerializeField] internal int[] DiamondForEachLvl = { 250, 250, 250, 250, 250 };
}
