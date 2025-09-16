using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    internal int itemType;
    [SerializeField] SpriteRenderer iconSprite;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] CircleCollider2D circleCollider;

    internal void ItemSetUp(ItemSample itemSample)
    {

    }
}
