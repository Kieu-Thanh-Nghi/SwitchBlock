using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartOfObstacle : MonoBehaviour
{
    [SerializeField] bool isPartBlack;
    [SerializeField] internal Transform tail;
    [SerializeField] internal SpriteRenderer partColor;
    [SerializeField] internal BoxCollider2D aPartCollider;

    internal bool IsHavingCollider()
    {
        return aPartCollider.enabled;
    }
    internal void SwitchAPart()
    {
        aPartCollider.enabled = !aPartCollider.enabled;
    }
}
