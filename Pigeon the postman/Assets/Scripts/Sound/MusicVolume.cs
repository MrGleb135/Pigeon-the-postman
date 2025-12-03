using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MusicVolume : MonoBehaviour
{
    public AudioSource musicSource;

    public GameObject canvas;
    public Slider slider;
    public TextMeshProUGUI volumeText;

    public float musicVolumeSave;

    // Позволяет сохранять один экземпляр скрипта между сценами
    public static MusicVolume instance;

    // Делам объект зыука неуничтожаемыми при смене сцен
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
        if (PlayerPrefs.HasKey("MusicVolumeSave"))
        {
            musicVolumeSave = PlayerPrefs.GetFloat("MusicVolumeSave");
        }
        else
        {
            musicVolumeSave = 0.5f;
        }

        slider.value = musicVolumeSave;
        musicSource.volume = musicVolumeSave;
        volumeText.text = Mathf.RoundToInt(musicVolumeSave * 100).ToString() + " %";

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
        musicVolumeSave = volume;
        musicSource.volume = volume;
        volumeText.text = Mathf.RoundToInt(volume * 100).ToString() + " %";

        PlayerPrefs.SetFloat("MusicVolumeSave", musicVolumeSave);
        PlayerPrefs.Save();
    }
}
