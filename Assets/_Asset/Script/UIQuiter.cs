using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuiter : MonoBehaviour
{
    public void QuitThisUI()
    {
        Debug.Log("quit");
        transform.parent.gameObject.SetActive(false);
    }
}
