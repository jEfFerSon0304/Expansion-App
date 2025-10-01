using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle simpleModeToggle;

    private void Start()
    {
        // Load saved values
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        simpleModeToggle.isOn = PlayerPrefs.GetInt("SimpleMode", 0) == 1;

        // Apply immediately
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);

        // Add listeners
        musicSlider.onValueChanged.AddListener((val) => AudioManager.Instance.SetMusicVolume(val));
        sfxSlider.onValueChanged.AddListener((val) => AudioManager.Instance.SetSFXVolume(val));
        simpleModeToggle.onValueChanged.AddListener((isOn) => PlayerPrefs.SetInt("SimpleMode", isOn ? 1 : 0));
    }
}
