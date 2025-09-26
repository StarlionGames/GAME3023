using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneUI : MonoBehaviour
{
    public void TryToFlee()
    {
        // add probability stuff later

        SceneManager.LoadScene("TestingScene");
    }

    public void Attack()
    {
        Debug.Log("player tried to attack! it didn't work!");
    }
}
