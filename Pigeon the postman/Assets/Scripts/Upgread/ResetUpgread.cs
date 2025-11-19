using UnityEngine;

public class ResetUpgread : MonoBehaviour
{
    public EnergyUpgrad energyUpgrade;
    public LettersUpgread lettersUpgread;
    public AdrenalineUpgread adrenalineUpgread;

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        energyUpgrade.currentStep = 100;
        PlayerPrefs.SetInt("EnergyUpgradeStep", energyUpgrade.currentStep);
        lettersUpgread.currentStep = 0;
        PlayerPrefs.SetInt("LettersUpgradeStep", lettersUpgread.currentStep);
        adrenalineUpgread.currentStep = 0;
        PlayerPrefs.SetInt("AdrenalineUpgradeStep", adrenalineUpgread.currentStep);

        energyUpgrade.energyCount.maxEnergy = 100;
        energyUpgrade.energyCount.energy = energyUpgrade.energyCount.maxEnergy;
        PlayerPrefs.SetInt("maxEnergy", energyUpgrade.energyCount.maxEnergy);
        lettersUpgread.lettersCount.maxLetters = 0;
        lettersUpgread.lettersCount.letters = lettersUpgread.lettersCount.maxLetters;
        PlayerPrefs.SetInt("LettersUpgradeStep", lettersUpgread.lettersCount.maxLetters);
        adrenalineUpgread.adrenalineCount.maxAdrenaline = 0;
        adrenalineUpgread.adrenalineCount.adrenaline = adrenalineUpgread.adrenalineCount.maxAdrenaline;
        PlayerPrefs.SetInt("LettersUpgradeStep", adrenalineUpgread.adrenalineCount.maxAdrenaline);

        energyUpgrade.ResetButtons();
        lettersUpgread.ResetButtons();
        adrenalineUpgread.ResetButtons();

        energyUpgrade.Button125.SetActive(true);
        lettersUpgread.Button2.SetActive(true);
        adrenalineUpgread.Button1.SetActive(true);

        PlayerPrefs.Save();
    }
}
