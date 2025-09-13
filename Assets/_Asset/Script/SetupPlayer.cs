using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class SetupPlayer : MonoBehaviour
{
    [SerializeField] GameObject currentPlayer;
    [SerializeField] GameObject currentSkin;

    public static SetupPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    internal void SetUpNewPlayerSkin(SkinToPlay skinToPlay)
    {
        GameObject newSkin = Instantiate(skinToPlay.gameObject, currentPlayer.transform);
        newSkin.transform.localScale = currentSkin.transform.localScale;
        Destroy(currentSkin);
        currentSkin = newSkin;
        currentPlayer.GetComponent<Player>().SetSkin(currentSkin.GetComponent<SkinToPlay>());
        DontDestroyOnLoad(currentPlayer);
    }

    public void ToGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
        StartCoroutine(waitToActivePlayer());
    }

    IEnumerator waitToActivePlayer()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().buildIndex == 1);
        currentPlayer.SetActive(true);
    }
}
