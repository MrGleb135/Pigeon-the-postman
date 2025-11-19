using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    private HouseID currentHouse;
    public LettersManager lettersManager;
    public LettersCount lettersCount;
    public Marcs marcs;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentHouse != null)
        {
            for (int i = 0; i < lettersManager.selectedHouses.Count; i++)
            {
                if (lettersManager.selectedHouses[i].houseNumber == currentHouse.houseID)
                {
                    marcs.marcsSumInARound = marcs.marcsSumInARound + lettersManager.selectedHouses[i].marcsVolume;
                    lettersCount.letters--;
                    lettersManager.selectedHouses.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HouseID house = other.GetComponent<HouseID>();
        if (house != null)
        {
            currentHouse = house;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        HouseID house = other.GetComponent<HouseID>();
        if (house != null && house == currentHouse)
        {
            currentHouse = null;
        }
    }
}
