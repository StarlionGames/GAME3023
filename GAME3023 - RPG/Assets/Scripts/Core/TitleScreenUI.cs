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
        StartCoroutine(GameManager.instance.sceneLoader.LoadAndContinue());
    }

}
