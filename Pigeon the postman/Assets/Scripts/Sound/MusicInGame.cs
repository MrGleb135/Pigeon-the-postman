using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicInGame : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI volumeText;

    void Start()
    {
        // Проверяем, что объект MusicVolume существует
        if (MusicVolume.instance != null)
        {
            // Устанавливаем начальное значение слайдера и текста
            slider.SetValueWithoutNotify(MusicVolume.instance.musicVolumeSave);
            volumeText.text = Mathf.RoundToInt(MusicVolume.instance.musicVolumeSave * 100).ToString() + " %";

            slider.onValueChanged.AddListener(SetVolume);
        }
    }

    void SetVolume(float value)
    {
        if (MusicVolume.instance != null)
        {
            // Меняем громкость на глобальном объекте музыки
            MusicVolume.instance.SetVolume(value);
            volumeText.text = Mathf.RoundToInt(value * 100).ToString() + " %";
        }
    }
}
