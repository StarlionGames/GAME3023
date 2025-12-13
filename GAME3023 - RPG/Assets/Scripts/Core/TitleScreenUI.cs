using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{
    public void ToOverworld()
    {
        GameManager.instance.sceneLoader.LoadNextScene((int)SceneDirectory.StartScene, SceneDirectory.PlainsCenter);
    }

    public void Continue()
    {
        StartCoroutine(GameManager.instance.sceneLoader.LoadAndContinue());
    }

}
