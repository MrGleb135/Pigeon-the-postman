using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundVolume : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip[] soundClips;

    public Slider slider;
    public TextMeshProUGUI volumeText;

    public float soundVolumeSave;

    // Позволяет музыке играть на всех сценах
    public static SoundVolume instance;
    void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        if (PlayerPrefs.HasKey("SoundVolumeSave"))
        {
            soundVolumeSave = PlayerPrefs.GetFloat("SoundVolumeSave");
        }

        slider.value = soundVolumeSave;
        soundSource.volume = soundVolumeSave;
        volumeText.text = Mathf.RoundToInt(soundVolumeSave * 100).ToString() + " %";

        slider.onValueChanged.AddListener(SetVolume); //вызывает SetVolume при изменении значения слайдера
    }

    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        soundVolumeSave = volume;
        soundSource.volume = volume;
        volumeText.text = Mathf.RoundToInt(volume * 100).ToString() + " %";

        PlayerPrefs.SetFloat("SoundVolumeSave", soundVolumeSave);
        PlayerPrefs.Save();
    }

    public void PlayRandomSound()
    {
        int index = Random.Range(0, soundClips.Length);
        soundSource.clip = soundClips[index];
        soundSource.Play();
    }
}
