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
        
        Debug.Log("fart " + item.Name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanPickUp = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CanPickUp = false;
    }
}
