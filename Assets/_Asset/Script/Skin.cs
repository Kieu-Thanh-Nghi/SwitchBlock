using UnityEngine;
using UnityEngine.Purchasing;
using TMPro;

public class Skin : MonoBehaviour
{
    [SerializeField] internal int skinState; //0.active 1.owned 2.WatchAD 3.PayMoney
    [SerializeField] internal int index;
    [SerializeField] TMP_Text priceText;
    [SerializeField] internal string productID;
    SkinStore store;

    public void setStore(SkinStore theStore)
    {
        store = theStore;
    }

    internal void fetchProduct()
    {
        if (productID == "") return;
        priceText.text = CodelessIAPStoreListener.Instance.GetProduct(productID).metadata.localizedPriceString;
    }
    public void SetupState(int theState, bool setNew = false)
    {
        ActiveWithSkinState[] theActives = GetComponentsInChildren<ActiveWithSkinState>(includeInactive: true);
        foreach(var theActive in theActives)
        {
            theActive.ActiveThis(theState);
            if (setNew)
            {
                theActive.UnActiveThis(skinState);
            }
        }
        skinState = theState;
    }

    public void ChangeSkin()
    {
        store.UnlockSkin(this);
    }
}
