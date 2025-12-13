using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{
    public void ToOverworld()
    {
        GameManager.instance.sceneLoader.LoadNextScene((int)SceneDirectory.StartScene, SceneDirectory.PlainsCenter);
        GameManager.instance.audioManager.ChangeBGM(AudioDirectory.OverworldMusic);
    }

    public void Continue()
    {
        StartCoroutine(GameManager.instance.sceneLoader.LoadAndContinue());
        GameManager.instance.audioManager.ChangeBGM(AudioDirectory.OverworldMusic);
    }
    public void CreditsScene()
    {
        GameManager.instance.sceneLoader.LoadNextScene
            ((int)SceneDirectory.StartScene, SceneDirectory.Credits);
    }
    public void CreditToStart()
    {
        GameManager.instance.sceneLoader.LoadNextScene
            ((int)SceneDirectory.Credits, SceneDirectory.StartScene);
    }
}
