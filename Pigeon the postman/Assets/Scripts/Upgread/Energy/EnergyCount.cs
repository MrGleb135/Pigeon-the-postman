using System.Collections;
using UnityEngine;

public class EnergyCount : MonoBehaviour
{
    public int maxEnergy = 100;
    public int energy;

    public OnGroundCheck OnGround;

    private Coroutine energyCoroutine;

    void Start()
    {
        energy = maxEnergy;
    }

 void Update()
    {
        bool isGrounded = OnGround.OnGround;

        if (isGrounded && energyCoroutine == null)
        {
            energyCoroutine = StartCoroutine(WaitForEnergy());
        }
        else if (!isGrounded && energyCoroutine != null)
        {
            StopCoroutine(energyCoroutine);
            energyCoroutine = null;
        }
    }

    private IEnumerator WaitForEnergy()
    {
        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            if (energy < maxEnergy)
            {
                energy += 1;
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}