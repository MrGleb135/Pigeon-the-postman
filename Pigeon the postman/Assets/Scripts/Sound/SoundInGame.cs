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
            // Устанавливаем начальное значение слайдера и текста
            slider.SetValueWithoutNotify(SoundVolume.instance.soundVolumeSave);
            UpdateVolumeText(SoundVolume.instance.soundVolumeSave);

            slider.onValueChanged.AddListener(SetVolume);
        }
    }

    void SetVolume(float value)
    {
        if (SoundVolume.instance != null)
        {
            // Меняем громкость звуков
            SoundVolume.instance.soundSource.volume = value;
            SoundVolume.instance.soundVolumeSave = value;

            // Обновляем UI первой сцены, если слайдер и текст существуют
            if (SoundVolume.instance.slider != null)
            {
                SoundVolume.instance.slider.SetValueWithoutNotify(value);
            }
            if (SoundVolume.instance.volumeText != null)
            {
                SoundVolume.instance.volumeText.text = Mathf.RoundToInt(value * 100).ToString() + " %";
            }

            PlayerPrefs.SetFloat("SoundVolumeSave", value);
            PlayerPrefs.Save();

            UpdateVolumeText(value);
        }
    }

    void UpdateVolumeText(float value)
    {
        volumeText.text = Mathf.RoundToInt(value * 100).ToString() + " %";
    }
}
