using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCount : MonoBehaviour
{
    public int maxEnergy = 100;
    public int energy;
    public Image EnergyScale;

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

        EnergyScale.fillAmount = ((1/(float)maxEnergy)*(float)energy);
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