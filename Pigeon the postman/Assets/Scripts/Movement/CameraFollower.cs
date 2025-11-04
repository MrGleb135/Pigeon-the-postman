using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    public float moveSmooth = 3f;
    public float zoomSmooth = 1.5f;
    public Vector2 offset = new Vector2(0f, 1.5f);

    public OnGroundCheck OnGround;
    public float groundZoom = 3f;
    public float airZoom = 7f;

    void LateUpdate()
    {
        bool isGrounded = OnGround.OnGround;
        
        Vector3 CameraPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        float moveLerpFactor = 1f - Mathf.Exp(-moveSmooth  * Time.deltaTime);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, CameraPosition, moveLerpFactor);

        transform.position = smoothedPosition;

        float targetZoom = isGrounded ? groundZoom : airZoom;
        float zoomLerpFactor = 1f - Mathf.Exp(-zoomSmooth * Time.deltaTime);

        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetZoom, zoomLerpFactor);
    }
}
