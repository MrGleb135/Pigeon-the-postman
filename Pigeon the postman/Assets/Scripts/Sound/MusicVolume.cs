using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicVolume : MonoBehaviour
{
    public AudioSource musicSource;

    public GameObject canvas;
    public Slider slider;
    public TextMeshProUGUI volumeText;

    public float musicVolumeSave;

    // Позволяет музыке играть на всех сценах
    public static MusicVolume instance;
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

        slider.onValueChanged.AddListener(SetVolume); //вызывает SetVolume при изменении значения слайдера
    }

    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        musicVolumeSave = volume;
        musicSource.volume = volume;
        volumeText.text = Mathf.RoundToInt(volume * 100).ToString() + " %";

        PlayerPrefs.SetFloat("MusicVolumeSave", musicVolumeSave);
        PlayerPrefs.Save();
    }
}
