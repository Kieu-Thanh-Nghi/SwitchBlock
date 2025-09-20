using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] internal bool switchState = false;
    [SerializeField] protected Transform startpoint;
    [SerializeField] protected PartOfObstacle[] parts;
    [SerializeField] PartOfObstacle alternativePart;
    [SerializeField] protected int n;
    [SerializeField] float min_length = 0.15f;
    Vector3 alternativePos;
    float baseScaleY = 1;
    float remain_length;
    protected GamePlayCtrler gamePlayCtrler;

    private void Awake()
    {
        alternativePos = alternativePart.transform.position;
        n = parts.Length;
        remain_length = 1 - min_length * n;        
    }
    private void Start()
    {
        gamePlayCtrler = GamePlayCtrler.Instance;
        gamePlayCtrler.DoWhenGameEnd += doWhenEndGame;
    }
    void doWhenEndGame() => gameObject.SetActive(false);
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lastpoint"))
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {

    }

    internal void SwitchParts()
    {
        switchState = !switchState;
        foreach(var part in parts)
        {
            part.SwitchAPart();

        }            
        alternativePart.SwitchAPart();
        swapToAlternative();
    }

    void swapToAlternative()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].IsHavingCollider() != alternativePart.IsHavingCollider())
            {
                var temp = alternativePart;
                alternativePart = parts[i];
                parts[i] = temp;
            }
        }
    }

    internal void SetStartPoint(Transform startPoint)
    {
        startpoint = startPoint;
    }

    [ContextMenu("sap xep parts")]
    internal void ArrangeParts()
    {
        alternativePart.transform.position = alternativePos;
        alternativePart.transform.localScale = new Vector3(min_length, baseScaleY);
        partsSuffle();
        CheckParts();
        randomPartsLength();
        n = parts.Length;
        connectParts();
    }

    [ContextMenu("random range")]
    void randomPartsLength()
    {
        float remainLength = remain_length;

        for (int i = 0; i < n - 1; i++)
        {
            float bonusLength;
            if (!parts[i].IsHavingCollider())
            {
                bonusLength = Random.Range(0, remainLength / 2);
            }
            else
            {
                bonusLength = Random.Range(remainLength / 2, remainLength);
            }
            
            remainLength = remainLength - bonusLength;
            parts[i].transform.localScale = new Vector3(min_length + bonusLength, baseScaleY);
        }
        parts[n-1].transform.localScale = new Vector3(min_length + remainLength, baseScaleY);
    }

    void CheckParts()
    {
        if(!parts[0].IsHavingCollider() && !parts[n-1].IsHavingCollider() && parts[n-2].IsHavingCollider())
        {
            n = parts.Length;
        }
        else
        {
            if (parts[n - 1].IsHavingCollider())
            {
                for (int i = n-2; i >= 0; i--)
                {
                    if (!parts[i].IsHavingCollider()) swapParts(i, n - 1);
                }
            }
            n = n - 1;
        }
        remain_length = 1 - min_length * n;
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
