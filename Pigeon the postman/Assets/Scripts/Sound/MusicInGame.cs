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
            UpdateVolumeText(MusicVolume.instance.musicVolumeSave);

            slider.onValueChanged.AddListener(SetVolume);
        }
    }

    void SetVolume(float value)
    {
        if (MusicVolume.instance != null)
        {
            // Меняем громкость музыки
            MusicVolume.instance.musicSource.volume = value;
            MusicVolume.instance.musicVolumeSave = value;

            // Обновляем UI первой сцены, если слайдер и текст существуют
            if (MusicVolume.instance.slider != null)
            {
                MusicVolume.instance.slider.SetValueWithoutNotify(value);
            }
            if (MusicVolume.instance.volumeText != null)
            {
                MusicVolume.instance.volumeText.text = Mathf.RoundToInt(value * 100).ToString() + " %";
            }

            PlayerPrefs.SetFloat("MusicVolumeSave", value);
            PlayerPrefs.Save();

            UpdateVolumeText(value);
        }
    }

    void UpdateVolumeText(float value)
    {
        volumeText.text = Mathf.RoundToInt(value * 100).ToString() + " %";
    }
}
