using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitTheScreen : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Camera cam;
    float changeRatio;
    // Start is called before the first frame update
    void Start()
    {
        FitScale(sr, cam);
    }

    void FitScale(SpriteRenderer sr, Camera cam)
    {
        float worldHeigh = cam.orthographicSize * 2f;
        float worldWidth = worldHeigh * cam.aspect;

        Vector2 spriteSize = sr.sprite.bounds.size;
        Vector3 scale = sr.transform.localScale;

        scale.x = worldWidth / spriteSize.x;
        scale.y = worldHeigh / spriteSize.y;

        changeRatio = scale.x / sr.transform.localScale.x;
        sr.transform.localScale = scale;
    }

    internal void SetPlayerScale(Transform playerTransform)
    {
        Vector3 newScale = playerTransform.localScale;
        newScale.x = newScale.x * changeRatio;
        newScale.y = newScale.y * changeRatio;
        playerTransform.localScale = newScale;
    }
}
