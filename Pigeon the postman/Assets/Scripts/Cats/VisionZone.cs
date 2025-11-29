using System.ComponentModel;
using UnityEngine;

public class VisionZone : MonoBehaviour
{
    public bool catSeePlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            catSeePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            catSeePlayer = false;
        }
    }
}
