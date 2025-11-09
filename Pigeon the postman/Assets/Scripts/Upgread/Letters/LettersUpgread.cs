using UnityEngine;

public class LettersUpgread : MonoBehaviour
{
    public LettersCount lettersCount;
    void Start()
    {
        if (PlayerPrefs.HasKey("maxLetters"))
        {
            lettersCount.maxLetters = PlayerPrefs.GetInt("maxLetters");
        }
    }

    void Update()
    {

    }
    
     public void LettersUpgrad1()
    {
        lettersCount.maxLetters = 1;
        lettersCount.letters = lettersCount.maxLetters;
        PlayerPrefs.SetInt("maxLetters", lettersCount.maxLetters);
        PlayerPrefs.Save();
    }
    public void LettersUpgrad2()
    {
        lettersCount.maxLetters = 2;
        lettersCount.letters = lettersCount.maxLetters;
        PlayerPrefs.SetInt("maxLetters", lettersCount.maxLetters);
        PlayerPrefs.Save();
    }
    public void LettersUpgrad3()
    {
        lettersCount.maxLetters = 3;
        lettersCount.letters = lettersCount.maxLetters;
        PlayerPrefs.SetInt("maxLetters", lettersCount.maxLetters);
        PlayerPrefs.Save();
    } 
    public void LettersUpgrad4()
    {
        lettersCount.maxLetters = 4;
        lettersCount.letters = lettersCount.maxLetters;
        PlayerPrefs.SetInt("maxLetters", lettersCount.maxLetters);
        PlayerPrefs.Save();
    } 
}
