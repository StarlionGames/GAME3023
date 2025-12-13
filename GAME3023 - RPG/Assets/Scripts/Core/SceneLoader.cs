using System;
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
    public void LoadNextScene(int thisScene, SceneDirectory nextScene)
    {
        StartCoroutine(CrossFadeToNewScene(thisScene, nextScene));
        //TODO: add different transition options
    }
    IEnumerator CrossFadeToNewScene(int thisScene, SceneDirectory nextScene)
    {
        yield return StartCoroutine(FadeIn());
        
        AsyncOperation load = SceneManager.LoadSceneAsync((int)nextScene, LoadSceneMode.Additive);
        while(!load.isDone) yield return null;

        SceneManager.UnloadSceneAsync(thisScene);

        yield return StartCoroutine(FadeOut());
    }
    public IEnumerator CrossFadeToOverworldScene(int thisScene, SceneDirectory nextScene, Action OnComplete)
    {
        yield return StartCoroutine(FadeIn());

        AsyncOperation load = SceneManager.LoadSceneAsync((int)nextScene, LoadSceneMode.Additive);
        while (!load.isDone) yield return null;

        Scene scene = SceneManager.GetSceneByBuildIndex((int)nextScene);
        foreach (var ob in scene.GetRootGameObjects())
        {
            if (ob.TryGetComponent(out Room rom)) { rom.Initialize(); yield return null; }
        }

        OnComplete?.Invoke(); // meant for injecting things into the coroutine

        SceneManager.UnloadSceneAsync(thisScene);

        yield return StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        sceneTransition.SetTrigger("Start");
        Debug.Log("start");
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator FadeOut()
    {
        sceneTransition.SetTrigger("End");
        Debug.Log("end");
        yield return new WaitForSeconds(0.5f);
    }
}
