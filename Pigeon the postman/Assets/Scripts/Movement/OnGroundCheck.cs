using System.Collections;
using UnityEngine;

public class OnGroundCheck : MonoBehaviour
{
    public bool OnGround = true;
    public float offGroundDelay = 0.1f;
    private Coroutine offGroundCoroutine;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("House") || collision.CompareTag("VisionZone") || collision.CompareTag("DeadZone") || collision.CompareTag("AdrenalineZone")) // Не считает коллизии с этими тегами
            return;

        OnGround = true;
        if (offGroundCoroutine != null)
        {
            StopCoroutine(offGroundCoroutine);
            offGroundCoroutine = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("House") || collision.CompareTag("VisionZone") || collision.CompareTag("DeadZone") || collision.CompareTag("AdrenalineZone")) // Не считает коллизии с этими тегами
            return;
            
        if (offGroundCoroutine == null)
        {
            offGroundCoroutine = StartCoroutine(OffGroundTimer());
        }
    }

    // Корутина, чтобы установить OnGround в false после 0.1 секунды
    private IEnumerator OffGroundTimer()
    {
        yield return new WaitForSeconds(offGroundDelay);
        OnGround = false;
        offGroundCoroutine = null;
    }
}