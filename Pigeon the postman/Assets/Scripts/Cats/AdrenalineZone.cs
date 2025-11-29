using UnityEngine;

public class AdrenalineZone : MonoBehaviour
{
    public EnergyCount energyCount;
    public AdrenalineCount adrenalineCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (adrenalineCount.adrenaline > 0)
            {
            adrenalineCount.adrenaline--;
            energyCount.energy = energyCount.energy + 30;
            }
        }
    }
}
