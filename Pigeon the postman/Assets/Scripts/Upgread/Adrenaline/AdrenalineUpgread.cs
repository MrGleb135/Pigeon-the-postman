using UnityEngine;

public class AdrenalineUpgread : MonoBehaviour
{
    public AdrenalineCount adrenalineCount;
    public Marcs marcs;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject ButtonEnd;
    public int currentStep = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("AdrenalineUpgradeStep"))
        {
            currentStep = PlayerPrefs.GetInt("AdrenalineUpgradeStep");
        }

        if (PlayerPrefs.HasKey("maxAdrenaline"))
        {
            adrenalineCount.maxAdrenaline = PlayerPrefs.GetInt("maxAdrenaline");
        }

        ResetButtons();
        switch (currentStep)
        {
            case 0:
                Button1.SetActive(true);
                break;
            case 1:
                Button2.SetActive(true);
                break;
            case 2:
                Button3.SetActive(true);
                break;
            case 3:
                Button4.SetActive(true);
                break;
            case 4:
                ButtonEnd.SetActive(true);
            break;
        }
    }
    
    public void AdrenalineUpgrad1()
    {
        if (marcs.marcs >= 5)
        {
            adrenalineCount.maxAdrenaline = 1;
            adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
            PlayerPrefs.SetInt("maxAdrenaline", adrenalineCount.maxAdrenaline);

            currentStep = 1;
            PlayerPrefs.SetInt("AdrenalineUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button2.SetActive(true);
        }
    }
    public void AdrenalineUpgrad2()
    {
        if (marcs.marcs >= 10)
        {
            adrenalineCount.maxAdrenaline = 2;
            adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
            PlayerPrefs.SetInt("maxAdrenaline", adrenalineCount.maxAdrenaline);

            currentStep = 2;
            PlayerPrefs.SetInt("AdrenalineUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button3.SetActive(true);
        }
    }
    public void AdrenalineUpgrad3()
    {
        if (marcs.marcs >= 15)
        {
            adrenalineCount.maxAdrenaline = 3;
            adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
            PlayerPrefs.SetInt("maxAdrenaline", adrenalineCount.maxAdrenaline);

            currentStep = 3;
            PlayerPrefs.SetInt("AdrenalineUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button4.SetActive(true);
        }
    }
    public void AdrenalineUpgrad4()
    {
        if (marcs.marcs >= 20)
        {
            adrenalineCount.maxAdrenaline = 4;
            adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
            PlayerPrefs.SetInt("maxAdrenaline", adrenalineCount.maxAdrenaline);

            currentStep = 4;
            PlayerPrefs.SetInt("AdrenalineUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            ButtonEnd.SetActive(true);
        }
    }
    
    public void ResetButtons()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        ButtonEnd.SetActive(false);
    }
}
