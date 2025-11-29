using UnityEngine;

public class RandomCat : MonoBehaviour
{
    public GameObject cat;
    float chance = 0.8f;

    void Start()
    {
        if (Random.value <= chance)
        {
            cat.SetActive(false);
        }
    }
}
