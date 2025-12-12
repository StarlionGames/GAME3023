using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }
    public Inventory inventory {  get; private set; }

    private void OnEnable()
    {
        if (Instance != this) { return; }
        SaveSystem.OnSaveLoaded += LoadPlayer;
    }
    private void OnDisable()
    {
        if (Instance != this) { return; }
        SaveSystem.OnSaveLoaded -= LoadPlayer;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

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
