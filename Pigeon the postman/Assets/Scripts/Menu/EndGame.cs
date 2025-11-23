using UnityEngine;

public class EndGame : MonoBehaviour
{
    public LettersCount lettersCount;
    public GameObject endMenu;
    public CameraUpgread сameraUpgread;
    public Marcs marcs;
    public GameObject task;
    
    void Start()
    {
        endMenu.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (lettersCount.letters <= 0)
            {
                task.SetActive(false);
                
                endMenu.SetActive(true);
                сameraUpgread.upgreadMenu = true;
                marcs.marcs = marcs.marcs + marcs.marcsSumInARound;
                PlayerPrefs.SetInt("MarcsCount", marcs.marcs);
                PlayerPrefs.Save();
            }
        }
    }
}