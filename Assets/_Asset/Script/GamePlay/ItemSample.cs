using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSample : MonoBehaviour
{
    [SerializeField] internal int weight;
    [SerializeField] Sample samplePrefab;
    Queue<Sample> samples = new();

    internal Sample GetSample()
    {
        if(samples.Count == 0)
        {
            return Instantiate(samplePrefab);
        }
        return samples.Dequeue();
    }

    internal void ReturnSample(Sample theSample)
    {
        samples.Enqueue(theSample);
    }
}
