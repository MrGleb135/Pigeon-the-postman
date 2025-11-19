using UnityEngine;

public class EnergyUpgrad : MonoBehaviour
{
    public EnergyCount energyCount;
    public Marcs marcs;

    public GameObject Button125;
    public GameObject Button150;
    public GameObject Button175;
    public GameObject Button200;
    public GameObject ButtonEnd;
    public int currentStep = 100;
  
    void Start()
    {
        if (PlayerPrefs.HasKey("EnergyUpgradeStep"))
        {
            currentStep = PlayerPrefs.GetInt("EnergyUpgradeStep");
        }

        if (PlayerPrefs.HasKey("maxEnergy"))
        {
            energyCount.maxEnergy = PlayerPrefs.GetInt("maxEnergy");
        }

        ResetButtons();
        switch (currentStep)
        {
            case 100:
                Button125.SetActive(true);
                break;
            case 125:
                Button150.SetActive(true);
                break;
            case 150:
                Button175.SetActive(true);
                break;
            case 175:
                Button200.SetActive(true);
                break;
            case 200:
                ButtonEnd.SetActive(true);
            break;
        }
    }

    public void EnergyUpgrad125()
    {
        if (marcs.marcs >= 5)
        {
            energyCount.maxEnergy = 125;
            energyCount.energy = energyCount.maxEnergy;
            PlayerPrefs.SetInt("maxEnergy", energyCount.maxEnergy);

            currentStep = 125;
            PlayerPrefs.SetInt("EnergyUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button150.SetActive(true);
        }
    }
    public void EnergyUpgrad150()
    {
        if (marcs.marcs >= 5)
        {
            energyCount.maxEnergy = 150;
            energyCount.energy = energyCount.maxEnergy;
            PlayerPrefs.SetInt("maxEnergy", energyCount.maxEnergy);

            currentStep = 150;
            PlayerPrefs.SetInt("EnergyUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button175.SetActive(true);
        }
    }   
    public void EnergyUpgrad175()
    {
        if (marcs.marcs >= 5)
        {
            energyCount.maxEnergy = 175;
            energyCount.energy = energyCount.maxEnergy;
            PlayerPrefs.SetInt("maxEnergy", energyCount.maxEnergy);

            currentStep = 175;
            PlayerPrefs.SetInt("EnergyUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button200.SetActive(true);
        }
    }
    public void EnergyUpgrad200()
    {
        if (marcs.marcs >= 5)
        {
            energyCount.maxEnergy = 200;
            energyCount.energy = energyCount.maxEnergy;
            PlayerPrefs.SetInt("maxEnergy", energyCount.maxEnergy);

            currentStep = 200;
            PlayerPrefs.SetInt("EnergyUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            ButtonEnd.SetActive(true);
        }
    }

    public void ResetButtons()
    {
        Button125.SetActive(false);
        Button150.SetActive(false);
        Button175.SetActive(false);
        Button200.SetActive(false);
        ButtonEnd.SetActive(false);
    }
}
