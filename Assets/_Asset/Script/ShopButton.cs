using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] SkinStore store;
    [SerializeField] float repeatRate;
    [SerializeField] GameObject currentSkinImage;
    int n;
    Vector3 scale;
    //bool isContinute = true;

    private void OnEnable()
    {
        scale = currentSkinImage.transform.localScale;
        n = store.skins.Length;
        InvokeRepeating(nameof(RandomSkinImage), 0, repeatRate);
    }

    //private void Update()
    //{
    //    if (!isContinute && !store.isActiveAndEnabled)
    //    {
    //        InvokeRepeating(nameof(RandomSkinImage), 0, repeatRate);
    //        isContinute = true;
    //    }
    //    if (isContinute && store.isActiveAndEnabled)
    //    {
    //        CancelInvoke();
    //        Destroy(currentSkinImage);
    //        isContinute = false;
    //    }
    //}
    void RandomSkinImage()
    {
        int i = Random.Range(1, n);
        GameObject skinImage = store.skins[i].GetComponentInChildren<SkinImage>().gameObject;
        GameObject newSkinImage = Instantiate(skinImage, this.transform);
        newSkinImage.transform.localScale = scale;
        Destroy(currentSkinImage);
        currentSkinImage = newSkinImage;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
