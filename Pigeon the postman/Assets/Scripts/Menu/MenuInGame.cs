using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    public GameObject MIG;
    private bool act;
    void Start()
    {
        MIG.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!act)
            {
                MIG.SetActive(true);
                act = true;
            }
            else
            {
                MIG.SetActive(false);
                act = false;
            }
        }
    }
}
