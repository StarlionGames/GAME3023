using UnityEngine;

public class GameUI : MonoBehaviour
{
    public void SaveGame()
    {
        GameManager.instance.SaveGame();
    }
}
