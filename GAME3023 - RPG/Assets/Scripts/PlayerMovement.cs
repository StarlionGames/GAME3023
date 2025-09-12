using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public void OnMovement(InputValue input)
    {
        direction = input.Get<Vector2>();
    }
    private void Update()
    {
        transform.Translate(new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime);
    }
}
