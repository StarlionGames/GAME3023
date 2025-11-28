using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    public void ToOverworld()
    {
        SceneManager.LoadScene("TestingScene");
    }

    public void Continue()
    {
        StartCoroutine(LoadAndContinue());
    }

    IEnumerator LoadAndContinue()
    {
        var async = SceneManager.LoadSceneAsync("TestingScene", LoadSceneMode.Additive);

        while (!async.isDone) { yield return null; }

        Save s = SaveSystem.LoadSave();

        Player p = FindFirstObjectByType<Player>();
        Debug.Log("Loaded player at " + p.transform.position);
        p.LoadPlayer(s);

        SceneManager.UnloadSceneAsync("StartScene");
    }
}
