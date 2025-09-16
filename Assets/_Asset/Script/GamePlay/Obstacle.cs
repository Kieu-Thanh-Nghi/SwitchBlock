using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] internal bool isStop;
    [SerializeField] Transform startpoint;
    [SerializeField] PartOfObstacle[] parts;
    [SerializeField] int n;
    [SerializeField] float min_length = 0, max_length = (1f / 3f);

    private void Start()
    {
        n = parts.Length;
    }

    internal void SwitchParts()
    {
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
    void arrangeParts()
    {
        partsSuffle();
        randomPartsLength();
        connectParts();
    }

    [ContextMenu("random range")]
    void randomPartsLength()
    {
        float sumOfLength = 0;
        for (int i = 0; i < n-1; i++)
        {
            float newRange = Random.Range(min_length, max_length);
            parts[i].transform.localScale = new Vector3(newRange, parts[i].transform.localScale.y);
            sumOfLength += newRange;
        }
        Debug.Log(1 - sumOfLength);
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
