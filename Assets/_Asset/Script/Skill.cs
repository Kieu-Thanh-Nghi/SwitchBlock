using System.IO;
using UnityEngine;
public class Skill : MonoBehaviour
{
    [SerializeField] protected int Quantity = 0;
    [SerializeField] protected int level = 1;
    [SerializeField] protected int diamondForOneUse = 150;
    protected string jsonFile;
    protected int effDuration;

    protected int[] effDurationPerLvl;
    [SerializeField] protected int[] DiamondForEachLvl = { 250, 250, 250, 250, 250 };

    public virtual void Config(string path)
    {
        
    }

    public virtual void EffActive()
    {

    }
}
