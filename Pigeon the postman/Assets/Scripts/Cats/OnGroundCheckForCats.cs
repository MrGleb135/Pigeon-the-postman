using System.Collections;
using UnityEngine;

public class OnGroundCheckForCats : MonoBehaviour
{
    public bool OnGround = true;
    public float offGroundDelay = 0.1f;
    private Coroutine offGroundCoroutine;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnGround = true;
        if (offGroundCoroutine != null)
        {
            StopCoroutine(offGroundCoroutine);
            offGroundCoroutine = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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