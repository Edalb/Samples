using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] PlayerSettings playerSettings;
    [SerializeField] PlayerStatistics playerStatistics;

    [SerializeField] bool loadData = false;
    void Awake()
    {
        if (loadData)
        {
            LoadData();
            FindObjectOfType<SkinsManager>().LoadSkin();
        }
    }
    private void LoadData()
    {
        playerSettings.sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 0.33f);
        playerSettings.musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.33f);
        playerSettings.skinNumber = PlayerPrefs.GetInt("skinNumber", 0);

        playerStatistics.highestScore = PlayerPrefs.GetInt("highestScore", 0);
        playerStatistics.satanTwos = PlayerPrefs.GetInt("satanTwos", 0);
        playerStatistics.coinsCollected = PlayerPrefs.GetInt("coinsCollected", 0);
        playerStatistics.soulsPunished = PlayerPrefs.GetInt("soulsPunished", 0);
    }
    public void SaveData()
    {
        //settings
        PlayerPrefs.SetFloat("sfxVolume", playerSettings.sfxVolume);
        PlayerPrefs.SetFloat("musicVolume", playerSettings.musicVolume);
        PlayerPrefs.SetInt("skinNumber", playerSettings.skinNumber);
        //statistics
        PlayerPrefs.SetInt("highestScore", playerStatistics.highestScore);
        PlayerPrefs.SetInt("satanTwos", playerStatistics.satanTwos);
        PlayerPrefs.SetInt("coinsCollected", playerStatistics.coinsCollected);
        PlayerPrefs.SetInt("soulsPunished", playerStatistics.soulsPunished);

        PlayerPrefs.Save();
    }
}
