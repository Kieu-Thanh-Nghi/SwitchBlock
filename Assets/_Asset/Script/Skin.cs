using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] internal int skinState; //0.active 1.owned 2.WatchAD 3.PayMoney
    [SerializeField] internal int index;
    [SerializeField] SkinStore store;

    public void setStore(SkinStore theStore)
    {
        store = theStore;
    }
    public void SetupState(int theState)
    {
        skinState = theState;
        ActiveWithSkinState[] theActives = GetComponentsInChildren<ActiveWithSkinState>(includeInactive: true);
        Debug.Log(theActives.Length);
        foreach(var theActive in theActives)
        {
            theActive.ActiveThis(skinState);
        }
    }

    public void ChangeSkin()
    {
        store.UnlockSkin(this);
    }
}
