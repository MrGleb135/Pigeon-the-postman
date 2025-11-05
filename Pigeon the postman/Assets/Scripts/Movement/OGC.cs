using UnityEngine;

public class OGC : MonoBehaviour
{
public OnGroundCheck OnGround;
    void Update()
    {
        bool isGrounded = OnGround.OnGround;
    }
}