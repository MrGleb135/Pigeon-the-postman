using UnityEngine;

public class OnGroundCheck : MonoBehaviour
{
    public bool OnGround = true;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        OnGround = true;
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        OnGround = false;
    }
}
