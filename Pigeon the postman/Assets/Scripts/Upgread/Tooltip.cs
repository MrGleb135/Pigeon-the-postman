using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public GameObject tooltip;

    public TextMeshProUGUI  price;
    public TextMeshProUGUI  upgread;

    public EnergyCount energyCount;
    public LettersCount lettersCount;
    public AdrenalineCount adrenalineCount;

    public int upgreadID; // 1 - energy, 2 - letters, 3 - adrenaline

    void Start()
    {
        tooltip.SetActive(false);
    }

    // Обновляет информацию в tooltip
    void Update()
    {
        switch (upgreadID)
        {
            case 1:
                switch (energyCount.maxEnergy)
                {
                    case 100:
                        price.text = "5";
                        upgread.text = "100 -> 125";
                        break;
                    case 125:
                        price.text = "10";
                        upgread.text = "125 -> 150";
                        break;
                    case 150:
                        price.text = "15";
                        upgread.text = "150 -> 175";
                        break;
                    case 175:
                        price.text = "20";
                        upgread.text = "175 -> 200";
                        break;
                    case 200:
                        price.text = "-";
                        upgread.text = "MAX";
                        break;
                }
                break;
            case 2:
                switch (lettersCount.maxLetters)
                {
                    case 1:
                        price.text = "5";
                        upgread.text = "1 -> 2";
                        break;
                    case 2:
                        price.text = "10";
                        upgread.text = "2 -> 3";
                        break;
                    case 3:
                        price.text = "15";
                        upgread.text = "3 -> 4";
                        break;
                    case 4:
                        price.text = "20";
                        upgread.text = "4 -> 5";
                        break;
                    case 5:
                        price.text = "-";
                        upgread.text = "MAX";
                        break;
                }
                break;
            case 3:
                switch (adrenalineCount.maxAdrenaline)
                {
                    case 0:
                        price.text = "5";
                        upgread.text = "0 -> 1";
                        break;
                    case 1:
                        price.text = "10";
                        upgread.text = "1 -> 2";
                        break;
                    case 2:
                        price.text = "15";
                        upgread.text = "2 -> 3";
                        break;
                    case 3:
                        price.text = "20";
                        upgread.text = "3 -> 4";
                        break;
                    case 4:
                        price.text = "-";
                        upgread.text = "MAX";
                        break;
                }
                break;
        }
    }

    // Показывает tooltip при наведении мыши
    void OnMouseEnter()
    {
        tooltip.SetActive(true);
    }

    // Скрывает tooltip при уходе мыши
    void OnMouseExit()
    {
        tooltip.SetActive(false);
    }
}
