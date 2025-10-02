using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedSample : Sample
{
    float attractSpeed = 20;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("ItemSpawner"))
        {
            CancelInvoke();
        }
        if (collision.CompareTag("Magnet"))
        {
            item.isStop = true;
            InvokeRepeating(nameof(ColloderWithMagnet), 0, Time.fixedDeltaTime);
        }
    }

    protected virtual void ColloderWithMagnet()
    {
        item.transform.position = Vector3.MoveTowards(item.transform.position,
            gamePlayCtrler.player.transform.position, attractSpeed * Time.fixedDeltaTime);
    }

    protected override void ColloderWithLastPoint()
    {
        base.ColloderWithLastPoint();
        CancelInvoke();
        item.isStop = false;
    }
    protected override void ColloderWithPlayer()
    {
        base.ColloderWithPlayer();
        CancelInvoke();
        item.isStop = false;
    }
}
