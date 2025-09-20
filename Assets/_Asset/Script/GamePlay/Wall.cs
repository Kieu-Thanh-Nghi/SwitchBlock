using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] Transform fixPosition;
    Player player;

    private void Start()
    {
        player = GamePlayCtrler.Instance.player;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = fixPosition.position;
        }
    }
}
