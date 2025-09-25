using UnityEngine;

public class LoadingMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;

    private void Start()
    {
        Invoke(nameof(LoadMenu), 0.5f);
    }

    void LoadMenu()
    {
        Menu.SetActive(true);
    }
}
