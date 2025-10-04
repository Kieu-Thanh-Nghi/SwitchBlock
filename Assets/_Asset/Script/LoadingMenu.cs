using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;

public class LoadingMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] TMP_Text text;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Invoke(nameof(LoadMenu), 0.5f);
        logIn();
    }

    void LoadMenu()
    {
        Menu.SetActive(true);
    }

    public void logIn()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        Debug.Log(status);
        if (status == SignInStatus.Success)
        {
            text.text = "Success";
        }
        else
        {
            text.text = "False";
        }
    }
}
