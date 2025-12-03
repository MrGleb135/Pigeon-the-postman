using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SoundVolume : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip[] soundClips;

    public GameObject canvas;
    public Slider slider;
    public TextMeshProUGUI volumeText;

    public float soundVolumeSave;

    // Позволяет сохранять один экземпляр скрипта между сценами
    public static SoundVolume instance;

    // Делам объект музыки неуничтожаемыми при смене сцен
    void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
        }
        else
        {
            Destroy(gameObject);
            Destroy(canvas);
        }
    }
    
    void Start()
    {
        if (PlayerPrefs.HasKey("SoundVolumeSave"))
        {
            soundVolumeSave = PlayerPrefs.GetFloat("SoundVolumeSave");
        }
        else
        {
            soundVolumeSave = 1f;
        }

        slider.value = soundVolumeSave;
        soundSource.volume = soundVolumeSave;
        volumeText.text = Mathf.RoundToInt(soundVolumeSave * 100).ToString() + " %";

        slider.onValueChanged.AddListener(SetVolume); // Вызывает SetVolume при изменении значения слайдера
    }

    void Update()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    // Вызывается при изменении значения слайдера
    public void SetVolume(float volume)
    {
        soundVolumeSave = volume;
        soundSource.volume = volume;
        volumeText.text = Mathf.RoundToInt(volume * 100).ToString() + " %";

        PlayerPrefs.SetFloat("SoundVolumeSave", soundVolumeSave);
        PlayerPrefs.Save();
    }

    // Проигрывает случайный звук
    public void PlayRandomSound()
    {
        int index = Random.Range(0, soundClips.Length);
        soundSource.clip = soundClips[index];
        soundSource.Play();
    }
}
