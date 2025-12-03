using UnityEngine;
using UnityEngine.UI;

public class PrintSelectedHouses : MonoBehaviour
{
    public LettersManager lettersManager;
    public Text housesText;

    // Проходит по всев выбранным домам из заносит их номера в текстовое поле
    void Update()
    {
        housesText.text = "";

        for (int i = 0; i < lettersManager.selectedHouses.Count; i++)
        {
            housesText.text = housesText.text + lettersManager.selectedHouses[i].houseNumber + " ";
        }
    }
}
