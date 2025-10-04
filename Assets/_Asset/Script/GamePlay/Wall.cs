using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] Transform fixPosition;
    GamePlayCtrler gamePlayCtrler;

    private void Start()
    {
        gamePlayCtrler = GamePlayCtrler.Instance;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gamePlayCtrler.sound.PlayDragSound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gamePlayCtrler.sound.PlayDragSound(true);
        }
    }
}
