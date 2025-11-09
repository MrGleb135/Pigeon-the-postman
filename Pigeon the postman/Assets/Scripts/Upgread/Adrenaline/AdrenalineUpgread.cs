using UnityEngine;

public class AdrenalineUpgread : MonoBehaviour
{
    public AdrenalineCount adrenalineCount;
    void Start()
    {
        if (PlayerPrefs.HasKey("maxAdrenaline"))
        {
            adrenalineCount.maxAdrenaline = PlayerPrefs.GetInt("maxAdrenaline");
        }
    }

    void Update()
    {

    }
    
     public void LettersUpgrad1()
    {
        adrenalineCount.maxAdrenaline = 1;
        adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
        PlayerPrefs.SetInt("maxAdrenaline", adrenalineCount.maxAdrenaline);
        PlayerPrefs.Save();
    }
    public void LettersUpgrad2()
    {
        adrenalineCount.maxAdrenaline = 2;
        adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
        PlayerPrefs.SetInt("maxAdrenaline", adrenalineCount.maxAdrenaline);
        PlayerPrefs.Save();
    }
    public void LettersUpgrad3()
    {
        adrenalineCount.maxAdrenaline = 3;
        adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
        PlayerPrefs.SetInt("maxAdrenaline", adrenalineCount.maxAdrenaline);
        PlayerPrefs.Save();
    } 
    public void LettersUpgrad4()
    {
        adrenalineCount.maxAdrenaline = 4;
        adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
        PlayerPrefs.SetInt("maxAdrenaline", adrenalineCount.maxAdrenaline);
        PlayerPrefs.Save();
    } 
}
