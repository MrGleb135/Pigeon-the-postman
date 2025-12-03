using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    public GameObject endGameGood;
    public GameObject endGameBad;

    public GameObject MIG;
    private bool active;

    void Start()
    {
        MIG.SetActive(false);
    }

    void Update()
    {
        if(!endGameGood.activeSelf && !endGameBad.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!active)
                {
                    MIG.SetActive(true);
                    active = true;
                }
                else
                {
                    MIG.SetActive(false);
                    active = false;
                }
            }
        }
    }
    
    public void ButtonContinue()
    {
        MIG.SetActive(false);
        active = false;
    }
}
