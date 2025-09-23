using UnityEngine;

public class ExplodeEff : MonoBehaviour
{
    [SerializeField] GameObject explodePrefab;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(Instantiate(explodePrefab, transform.position, transform.rotation), 2);
        }
    }
}
