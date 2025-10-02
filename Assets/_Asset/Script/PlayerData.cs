using System.IO;
using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [SerializeField] internal bool isNoAd = false;
    [SerializeField] internal int diamond = 0;
    [SerializeField] internal Magnet magnet = new();
    [SerializeField] internal Rocket rocket = new();
    [SerializeField] internal X2Multiplier x2Mutiplier = new();
}
