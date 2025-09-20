using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartOfObstacle : MonoBehaviour
{
    [SerializeField] internal bool isPartBlack;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GamePlayCtrler.Instance.EndTheGame();
        }
    }
}
