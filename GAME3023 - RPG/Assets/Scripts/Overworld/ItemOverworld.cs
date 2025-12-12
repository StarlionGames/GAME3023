using System;
using UnityEngine;

// items can be picked up in the overworld
public class ItemOverworld : MonoBehaviour, Interactable, Initialize
{
    [SerializeField] Item item;

    public ID globalID => GetComponent<ID>();
    bool CanPickUp = false;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    public void Initialize()
    {
        if (!SaveSystem.CurrentSave._obtainedOverworldItems.Contains(globalID.id)) { return; }
        else
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
        Destroy(gameObject);
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
