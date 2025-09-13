using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    float lastHeldX;
    float lastHeldY;
    
    Animator anim => gameObject.GetComponent<Animator>();
    PlayerMovement move => gameObject.GetComponent<PlayerMovement>();
    private void Update()
    {
        anim.SetFloat("Magnitude", move.direction.magnitude);   

        if (move.direction.magnitude < 0.1f)
        {
            SetDirections(lastHeldX, lastHeldY);
            return;
        }
        else
        {
            SetDirections(move.direction.x, move.direction.y);
            lastHeldX = move.direction.x;
            lastHeldY = move.direction.y;
        }
    }
    void SetDirections(float x, float y)
    {
        anim.SetFloat("X", x);
        anim.SetFloat("Y", y);
    }
}
