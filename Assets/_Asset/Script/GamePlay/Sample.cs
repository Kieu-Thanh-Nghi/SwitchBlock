using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    Item item;
    internal void SetUp(Item item)
    {
        this.item = item;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lastpoint"))
        {
            item.DeActiveItem();
        }
    }
}
