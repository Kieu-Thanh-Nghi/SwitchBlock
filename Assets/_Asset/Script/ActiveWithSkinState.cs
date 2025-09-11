using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWithSkinState : MonoBehaviour
{
    [SerializeField] int StateToActive;

    public void ActiveThis(int currentState)
    {
        if (currentState != StateToActive) return;
        gameObject.SetActive(true);
    }

    public void UnActiveThis(int theState)
    {
        if (theState != StateToActive) return;
        gameObject.SetActive(false);
    }
}
