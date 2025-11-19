using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    Interactable _interactable;
    Rigidbody2D rb => gameObject.GetComponent<Rigidbody2D>();
    Canvas _canvas;
    private void OnEnable()
    {
        _canvas = GetComponentInChildren<Canvas>();
        _canvas.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        _canvas.gameObject.SetActive(true);
    }
    public void OnMovement(InputValue input)
    {
        direction = input.Get<Vector2>();

        MovePlayer();
    }
    void MovePlayer()
    {
        rb.linearVelocity = direction * speed;
    }
    public void OnInteract()
    {
        if (_interactable != null)
        {
            _interactable.Interact();
        }
    }

    public void SetInteractable(GameObject _obj)
    {
        if (_obj.TryGetComponent(out Interactable i)) { _interactable = i; }

        _canvas.gameObject.SetActive(true);
    }
    public void EraseInteractable() { _interactable = null; _canvas.gameObject.SetActive(false); }
}
