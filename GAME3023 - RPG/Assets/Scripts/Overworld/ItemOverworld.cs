using System;
using UnityEngine;

// items can be picked up in the overworld
public class ItemOverworld : MonoBehaviour, Interactable
{
    [SerializeField] Item item;

    public ID globalID => GetComponent<ID>();
    bool CanPickUp = false;
    private void OnEnable()
    {
        SaveSystem.OnSaveLoaded += Initialize;
    }
    private void OnDisable()
    {
        SaveSystem.OnSaveLoaded -= Initialize;
    }
    public void Initialize(Save save)
    {
        if (save._obtainedOverworldItems.Contains(globalID.id)) 
        { 
            gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        if (!CanPickUp) { return; }
        
        Debug.Log("Added " + item.Name + " to inventory.");
        Player.Instance.inventory.AddToInventory(item, 1);
        SaveSystem.CurrentSave._obtainedOverworldItems.Add(globalID.id);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanPickUp = true;

        if (collision.TryGetComponent(out PlayerMovement player))
        {
            player.SetInteractable(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanPickUp = false;

        if (collision.TryGetComponent(out PlayerMovement player))
        {
            player.EraseInteractable();
        }
    }
}
