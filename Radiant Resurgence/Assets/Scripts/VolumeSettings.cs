using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider radioSlider;
    [SerializeField] private Slider windSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume")){
            LoadVolume();
        }
        else{
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
            SetRadioVolume();
            SetWindVolume();
        }
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void SetRadioVolume()
    {
        float volume = radioSlider.value;
        myMixer.SetFloat("Radio", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("radioVolume", volume);
    }

    public void SetWindVolume()
    {
        float volume = windSlider.value;
        myMixer.SetFloat("Wind", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("windVolume", volume);
    }

    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        radioSlider.value = PlayerPrefs.GetFloat("radioVolume");
        windSlider.value = PlayerPrefs.GetFloat("windVolume");

        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
        SetRadioVolume();
        SetWindVolume();
    }

}