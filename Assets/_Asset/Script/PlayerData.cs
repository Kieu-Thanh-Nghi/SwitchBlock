using System.IO;
using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [SerializeField] int diamond = 0;
    GameObject usingBox;
    [SerializeField] internal Magnet magnet = new();
    [SerializeField] internal Rocket rocket = new();
    [SerializeField] internal X2Multiplier x2Mutiplier = new();
}
