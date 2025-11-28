using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }
    public Inventory inventory {  get; private set; }

    private void OnEnable()
    {
        SaveSystem.OnSaveLoaded += LoadPlayer;
    }
    private void OnDisable()
    {
        SaveSystem.OnSaveLoaded -= LoadPlayer;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            inventory = GetComponentInChildren<Inventory>();
        }
    }

    public void LoadPlayer(Save save)
    {
        PlayerData data = save._player;

        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];

        transform.position = pos;
    }
}
