using System.Collections;
using UnityEngine;

public class OnGroundCheck : MonoBehaviour
{
    public bool OnGround = true;
    public float offGroundDelay = 0.1f;
    private Coroutine offGroundCoroutine;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("House"))
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
        if (collision.CompareTag("House"))
            return;
            
        if (offGroundCoroutine == null)
        {
            offGroundCoroutine = StartCoroutine(OffGroundTimer());
        }
    }

    private IEnumerator OffGroundTimer()
    {
        yield return new WaitForSeconds(offGroundDelay);
        OnGround = false;
        offGroundCoroutine = null;
    }
}