using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] internal int skinState; //0.active 1.owned 2.WatchAD 3.PayMoney
    [SerializeField] internal int index;
    SkinStore store;

    public void setStore(SkinStore theStore)
    {
        store = theStore;
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
