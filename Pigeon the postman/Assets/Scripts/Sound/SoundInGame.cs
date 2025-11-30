using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundInGame : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI volumeText;

    void Start()
    {
        // Проверяем, что объект SoundVolume существует
        if (SoundVolume.instance != null)
        {
            slider.onValueChanged.RemoveAllListeners();
            
            // Устанавливаем начальное значение слайдера и текста
            slider.value = SoundVolume.instance.soundVolumeSave;
            volumeText.text = Mathf.RoundToInt(SoundVolume.instance.soundVolumeSave * 100).ToString() + " %";

            slider.onValueChanged.AddListener(SetVolume);
        }
    }

    void SetVolume(float value)
    {
        if (SoundVolume.instance != null)
        {
            // Меняем громкость на глобальном объекте музыки
            SoundVolume.instance.SetVolume(value);
            volumeText.text = Mathf.RoundToInt(value * 100).ToString() + " %";
        }
    }
}
