using UnityEngine;

public class LettersUpgread : MonoBehaviour
{
    public LettersCount lettersCount;
    public Marcs marcs;

    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject ButtonEnd;
    public int currentStep = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("LettersUpgradeStep"))
        {
            currentStep = PlayerPrefs.GetInt("LettersUpgradeStep");
        }

        if (PlayerPrefs.HasKey("maxLetters"))
        {
            lettersCount.maxLetters = PlayerPrefs.GetInt("maxLetters");
        }

        ResetButtons();
        switch (currentStep)
        {
            case 0:
                Button2.SetActive(true);
                break;
            case 1:
                Button3.SetActive(true);
                break;
            case 2:
                Button4.SetActive(true);
                break;
            case 3:
                Button5.SetActive(true);
                break;
            case 4:
                ButtonEnd.SetActive(true);
            break;
        }
    }
    
    // Улучшение до 2 писем
    public void LettersUpgrad1()
    {
        if (marcs.marcs >= 5)
        {
            lettersCount.maxLetters = 2;
            lettersCount.letters = lettersCount.maxLetters;
            PlayerPrefs.SetInt("maxLetters", lettersCount.maxLetters);

            currentStep = 1;
            PlayerPrefs.SetInt("LettersUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 5;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button3.SetActive(true);
        }
    }

    // Улучшение до 3 писем
    public void LettersUpgrad2()
    {
        if (marcs.marcs >= 10)
        {
            lettersCount.maxLetters = 3;
            lettersCount.letters = lettersCount.maxLetters;
            PlayerPrefs.SetInt("maxLetters", lettersCount.maxLetters);

            currentStep = 2;
            PlayerPrefs.SetInt("LettersUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 10;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button4.SetActive(true);
        }
    }

    // Улучшение до 4 писем
    public void LettersUpgrad3()
    {
        if (marcs.marcs >= 15)
        {
            lettersCount.maxLetters = 4;
            lettersCount.letters = lettersCount.maxLetters;
            PlayerPrefs.SetInt("maxLetters", lettersCount.maxLetters);

            currentStep = 3;
            PlayerPrefs.SetInt("LettersUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 15;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            Button5.SetActive(true);
        }
    }

    // Улучшение до 5 писем
    public void LettersUpgrad4()
    {
        if (marcs.marcs >= 20)
        {
            lettersCount.maxLetters = 5;
            lettersCount.letters = lettersCount.maxLetters;
            PlayerPrefs.SetInt("maxLetters", lettersCount.maxLetters);

            currentStep = 4;
            PlayerPrefs.SetInt("LettersUpgradeStep", currentStep);

            marcs.marcs = marcs.marcs - 20;
            PlayerPrefs.SetInt("MarcsCount", marcs.marcs);

            PlayerPrefs.Save();

            ResetButtons();
            ButtonEnd.SetActive(true);
        }
    } 
    
    // Сброс кнопок
    public void ResetButtons()
    {
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        Button5.SetActive(false);
        ButtonEnd.SetActive(false);
    }
}
