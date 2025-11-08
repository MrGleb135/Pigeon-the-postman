using UnityEngine;

public class EnergyCount : MonoBehaviour
{
    public int maxEnergy = 101;
    public int energy;

    public OnGroundCheck OnGround;

    void Start()
    {
        energy = maxEnergy;
    }

    void Update()
    {
        bool isGrounded = OnGround.OnGround;
    }
}