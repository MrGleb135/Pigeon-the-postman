using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject tasks;
    public CameraUpgread сameraUpgread;
    public CameraFollower cameraFollower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            сameraUpgread.upgreadMenu = true;
            endMenu.SetActive(true);
            tasks.SetActive(false);
        }
    }
}
