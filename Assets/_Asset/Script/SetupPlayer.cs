using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class SetupPlayer : MonoBehaviour
{
    [SerializeField] GameObject currentPlayer;
    [SerializeField] GameObject currentSkin;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(currentPlayer);
    }
    internal void SetUpNewPlayerSkin(SkinToPlay skinToPlay)
    {
        GameObject newSkin = Instantiate(skinToPlay.gameObject, currentPlayer.transform);
        newSkin.transform.localScale = currentSkin.transform.localScale;
        Destroy(currentSkin);
        currentSkin = newSkin;
        currentPlayer.GetComponent<Player>().SetSkin(currentSkin.GetComponent<SkinToPlay>());
    }

    public void ToGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
        StartCoroutine(waitToActivePlayer());
    }

    IEnumerator waitToActivePlayer()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().buildIndex == 1 &&
                                         GamePlayCtrler.Instance != null);
        currentPlayer.SetActive(true);
        Destroy(gameObject);
    }
}
