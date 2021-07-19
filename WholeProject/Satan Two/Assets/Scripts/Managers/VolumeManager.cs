using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] PlayerSettings playerSettings;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] AudioSource musicSource;
    void Start()
    {
        sfxSlider.value = playerSettings.sfxVolume;
        musicSlider.value = playerSettings.musicVolume;
    }
    public void UpdateSfxVolume()
    {
        playerSettings.sfxVolume = sfxSlider.value;
    }
    public void UpdateMusicVolume()
    {
        playerSettings.musicVolume = musicSlider.value;
        musicSource.volume = musicSlider.value;
    }
    public void InstantiateSound()
    {

    }
}
