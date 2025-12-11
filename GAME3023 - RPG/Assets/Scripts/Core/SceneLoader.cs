using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneDirectory
{
    Manager = 0,
    StartScene = 1,
    Battle = 2,
    PlainsCenter = 3,
    PlainsLeft = 4,
    PlainsRight = 5
}

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Animator sceneTransition;
    
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public IEnumerator LoadAndContinue()
    {
        loadingScreen.SetActive(true);
        var async = SceneManager.LoadSceneAsync((int)SceneDirectory.PlainsCenter, LoadSceneMode.Additive);
        scenesLoading.Add(async);

        while (!async.isDone) { yield return null; }

        Save s = SaveSystem.LoadSave();

        Player p = FindFirstObjectByType<Player>();
        Debug.Log("Loaded player at " + p.transform.position);
        p.LoadPlayer(s);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneDirectory.StartScene));

        StartCoroutine(GetSceneLoadProgress());
    }

    public IEnumerator GetSceneLoadProgress()
    {
        for(int i =0; i <scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }

        loadingScreen.SetActive(false);
        scenesLoading = null;
    }

    public void LoadNextScene(SceneDirectory thisScene, SceneDirectory nextScene)
    {
        SceneManager.LoadSceneAsync((int)nextScene, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync((int)thisScene);
    }
}
