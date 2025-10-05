using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitTheScreen : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Camera cam;
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

        sr.transform.localScale = scale;
    }
}
