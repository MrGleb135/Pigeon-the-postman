using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject tasks;

    public CameraUpgread сameraUpgread;
    public CameraFollower cameraFollower;
    public CatMovement catMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            сameraUpgread.upgreadMenu = true;
            endMenu.SetActive(true);
            tasks.SetActive(false);
        }

        if (collision.CompareTag("Building"))
        {
            catMovement.direction = -catMovement.direction;
        }
    }
}
