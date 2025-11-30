using UnityEngine;

public class SettingsInMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        settingsMenu.SetActive(false);
    }

    public void settingsButtonOn()
    {
        settingsMenu.SetActive(true);
    }

    public void settingsButtonOff()
    {
        settingsMenu.SetActive(false);
    }
}
