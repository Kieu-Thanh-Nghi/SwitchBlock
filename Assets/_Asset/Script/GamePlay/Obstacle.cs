using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] internal bool switchState = false;
    [SerializeField] Transform startpoint;
    [SerializeField] PartOfObstacle[] parts;
    [SerializeField] int n;
    [SerializeField] float min_length = 0.15f, max_length = (1f / 3f);

    private void Start()
    {
        n = parts.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lastpoint"))
        {
            gameObject.SetActive(false);
        }
    }

    internal void SwitchParts()
    {
        switchState = !switchState;
        foreach(var part in parts)
        {
            part.SwitchAPart();
        }
    }

    internal void SetStartPoint(Transform startPoint)
    {
        startpoint = startPoint;
    }

    [ContextMenu("sap xep parts")]
    internal void ArrangeParts()
    {
        partsSuffle();
        randomPartsLength();
        connectParts();
    }

    [ContextMenu("random range")]
    void randomPartsLength()
    {
        bool checkIsHavingCollider = false;
        float sumOfLength = 0;
        for (int i = 0; i < n-1; i++)
        {
            checkIsHavingCollider = checkIsHavingCollider && parts[i].IsHavingCollider();
            float newRange = Random.Range(min_length, max_length);
            if(min_length > (1 - (sumOfLength + newRange)))
            {
                newRange = 1 - sumOfLength;
            }
            if(sumOfLength + newRange > 0.98f)
            {
                if (!checkIsHavingCollider)
                {
                    for(int j = i+1; j < n-1; j++)
                    {
                        if (parts[j].IsHavingCollider())
                        {
                            swapParts(i, j);
                            checkIsHavingCollider = true;
                            break;
                        }
                    }
                }
            }
            parts[i].transform.localScale = new Vector3(newRange, parts[i].transform.localScale.y);       
            sumOfLength += newRange;

        }
        if(sumOfLength < 1f)
        {
            parts[n-1].transform.localScale = new Vector3(1 - sumOfLength, parts[n - 1].transform.localScale.y);
        }
    }

    void connectParts()
    {
        parts[0].transform.position = startpoint.position;
        for(int i = 1; i< n; i++)
        {
            parts[i].transform.position = parts[i - 1].tail.position;
        }
    }

    void partsSuffle()
    {
        for(int i = 0; i < n; i++)
        {
            int randomIndex = Random.Range(i, n);
            swapParts(i, randomIndex);
        }
    }

    void swapParts(int a, int b)
    {
        PartOfObstacle temp = parts[a];
        parts[a] = parts[b];
        parts[b] = temp;
    }
}
