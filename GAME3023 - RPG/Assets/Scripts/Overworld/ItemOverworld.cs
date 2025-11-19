using UnityEngine;

// items can be picked up in the overworld
public class ItemOverworld : MonoBehaviour, Interactable
{
    [SerializeField] Item item;
    bool CanPickUp = false;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    public void Interact()
    {
        if (!CanPickUp) { return; }
        
        Debug.Log("Added " + item.Name + " to inventory.");
        Player.Instance.inventory.AddToInventory(item, 1);
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
