using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public GameObject KeyE;

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
                // Если ID выбранного дома совпадает с домом, в котором стоит игрок
                if (lettersManager.selectedHouses[i].houseNumber == currentHouse.houseID)
                {
                    marcs.marcsSumInARound = marcs.marcsSumInARound + lettersManager.selectedHouses[i].marcsVolume;
                    lettersCount.letters--;
                    lettersManager.selectedHouses.RemoveAt(i);
                    KeyE.SetActive(false);
                    break;
                }
            }
        }
    }

    // Срабатывает, когда игрок входит в зону доставки письма
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, имеет ли объект компонент HouseID
        HouseID house = other.GetComponent<HouseID>();
        if (house != null)
        {
            currentHouse = house;

            // Проверяем, есть ли этот дом в списке выбранных для доставки писем
            for (int i = 0; i < lettersManager.selectedHouses.Count; i++)
            {
                if (lettersManager.selectedHouses[i].houseNumber == currentHouse.houseID)
                {
                    KeyE.SetActive(true);
                    break;
                }
            }
        }
    }

    // Срабатывает, когда игрок выходит из зоны доставки письма
    private void OnTriggerExit2D(Collider2D other)
    {
        HouseID house = other.GetComponent<HouseID>();
        if (house != null && house == currentHouse)
        {
            currentHouse = null;
            KeyE.SetActive(false);
        }
    }
}
