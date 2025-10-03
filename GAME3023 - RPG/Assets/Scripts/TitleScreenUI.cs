using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    public void ToOverworld()
    {
        SceneManager.LoadScene("TestingScene");
    }
}
