using System.Collections.Generic;
using UnityEngine;

public class LettersManager : MonoBehaviour
{
    public EnergyCount energyCount;
    public LettersCount lettersCount;
    public AdrenalineCount adrenalineCount;

    public GameObject task;

    [Header("Список всех домов")]
    public List<LettersData> houses = new List<LettersData>();

    [Header("Выбранные дома")]
    public List<LettersData> selectedHouses = new List<LettersData>();

    public void StartGame()
    {
        SelectRandomHouses();
        energyCount.energy = energyCount.maxEnergy;
        lettersCount.letters = lettersCount.maxLetters;
        adrenalineCount.adrenaline = adrenalineCount.maxAdrenaline;
        task.SetActive(true);
    }

    public void SelectRandomHouses()
    {
        selectedHouses.Clear();

        int count = Mathf.Clamp(lettersCount.maxLetters, 0, houses.Count);

        List<LettersData> temp = new List<LettersData>(houses);

        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, temp.Count);
            selectedHouses.Add(temp[rand]);
            temp.RemoveAt(rand);
        }
    }
}
