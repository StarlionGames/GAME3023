using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }
    public Inventory inventory {  get; private set; }

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
}
