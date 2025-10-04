using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] internal Player player;
    Vector3 position;
    Vector3 deltaPos;
    Camera cam;
    Vector3 min, max;
    float halfWidth;
    Vector3 tempPos;

    private void Start()
    {
        cam = Camera.main;
        min = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        max = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        halfWidth = player.skinSprite.bounds.extents.x;
        min.x += halfWidth; max.x -= halfWidth;
    }

    internal void SetPlayer(Player thePlayer)
    {
        player = thePlayer;
        cam = Camera.main;
        min = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        max = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        halfWidth = player.skinSprite.bounds.extents.x;
        min.x += halfWidth; max.x -= halfWidth;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            position = cam.ScreenToWorldPoint(Input.mousePosition);
        }        
        if (Input.GetMouseButton(0))
        {
            deltaPos = cam.ScreenToWorldPoint(Input.mousePosition) - position;
            position = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if(player != null) player.transform.position += new Vector3(deltaPos.x, 0,0);
        deltaPos = Vector3.zero;
        keepPlayerOnScreen();
    }

    void keepPlayerOnScreen()
    {
        tempPos = player.transform.position;
        tempPos.x = Mathf.Clamp(tempPos.x, min.x, max.x);
        player.transform.position = tempPos;
    }
}
