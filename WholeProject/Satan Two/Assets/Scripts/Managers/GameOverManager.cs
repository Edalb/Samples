using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] PlayerStatistics playerStatistics;

    [Header ("Current Game")]
    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] TextMeshProUGUI satanTwosText;
    [SerializeField] TextMeshProUGUI coinsCollectedText;
    [SerializeField] TextMeshProUGUI soulsPunishedText;

    [Header("Total Stats")]
    [SerializeField] TextMeshProUGUI highestScoreText;
    [SerializeField] TextMeshProUGUI totalSatanTwosText;
    [SerializeField] TextMeshProUGUI totalCoinsCollectedText;
    [SerializeField] TextMeshProUGUI totalSoulsPunishedText;
    private void Start()
    {
        LoadData();
    }
    private void LoadData()
    {
        LoadCurrentGameData();
        LoadStatisticsData();
    }
    private void LoadCurrentGameData()
    {
        gameScoreText.text = gameData.gameScore.ToString();
        satanTwosText.text = gameData.satanTwos.ToString();
        coinsCollectedText.text = gameData.coinsCollected.ToString();
        soulsPunishedText.text = gameData.soulsPunished.ToString();
    }
    private void LoadStatisticsData()
    {
        highestScoreText.text = playerStatistics.highestScore.ToString();
        totalSatanTwosText.text = playerStatistics.satanTwos.ToString();
        totalCoinsCollectedText.text = playerStatistics.coinsCollected.ToString();
        totalSoulsPunishedText.text = playerStatistics.soulsPunished.ToString();
    }
}
