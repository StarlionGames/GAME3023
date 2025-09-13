using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    Rigidbody2D rb => gameObject.GetComponent<Rigidbody2D>();
    public void OnMovement(InputValue input)
    {
        direction = input.Get<Vector2>();

        MovePlayer();
    }
    void MovePlayer()
    {
        rb.linearVelocity = direction * speed;
    }
}
