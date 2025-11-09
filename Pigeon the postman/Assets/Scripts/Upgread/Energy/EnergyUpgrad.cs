using UnityEngine;

public class EnergyUpgrad : MonoBehaviour
{
    public EnergyCount energyCount;
  
    void Start()
    {
        if (PlayerPrefs.HasKey("maxEnergy"))
        {
            energyCount.maxEnergy = PlayerPrefs.GetInt("maxEnergy");
        }
    }

    void Update()
    {

    }

    public void EnergyUpgrad125()
    {
        energyCount.maxEnergy = 125;
        energyCount.energy = energyCount.maxEnergy;
        PlayerPrefs.SetInt("maxEnergy", energyCount.maxEnergy);
        PlayerPrefs.Save();
    }
    public void EnergyUpgrad150()
    {
        energyCount.maxEnergy = 150;
        energyCount.energy = energyCount.maxEnergy;
        PlayerPrefs.SetInt("maxEnergy", energyCount.maxEnergy);
        PlayerPrefs.Save();
    }   
    public void EnergyUpgrad175()
    {
        energyCount.maxEnergy = 175;
        energyCount.energy = energyCount.maxEnergy;
        PlayerPrefs.SetInt("maxEnergy", energyCount.maxEnergy);
        PlayerPrefs.Save();
    } 
        public void EnergyUpgrad200()
    {
        energyCount.maxEnergy = 200;
        energyCount.energy = energyCount.maxEnergy;
        PlayerPrefs.SetInt("maxEnergy", energyCount.maxEnergy);
        PlayerPrefs.Save();
    } 
}
