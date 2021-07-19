using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] PlayerStatistics playerStatistics;
    [SerializeField] PlayerSettings playerSettings;
    private GameScore gameScoreText;
    private Lifes lifesText;

    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Player playerPrefab;
    [SerializeField] Soul soulPrefab;
    [SerializeField] Collectible[] collectiblesPrefabs;
    [SerializeField] SkinsAvailable skinsAvailable;

    [SerializeField] float maxSpawnDistanceX;
    [SerializeField] float spawnDistanceY;

    private IEnumerator spawnObjects;
    [SerializeField] float startCollectibleSpawnCooldown = 6f;
    private float collectibleSpawnCooldown;
    private float waitAmount = 0.01f;
    private float gameStage = 0f;
    [SerializeField] float baseSpeed = 5f;
    [SerializeField] float gameStageIncrease = 0.02f;
    [SerializeField] float randomSpeedRange = 1f;
    private float currentSpeed;
    void Awake()
    {
        gameScoreText = FindObjectOfType<GameScore>();
        lifesText = FindObjectOfType<Lifes>();
    }
    private void Start()
    {
        GameStarted();
        spawnObjects = SpawnObjects();
        StartCoroutine(spawnObjects);
        InvokeRepeating("SpawnSouls", 0f, 2f);
    }
    private IEnumerator SpawnObjects()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        while (true)
        {
            yield return wait;
            collectibleSpawnCooldown -= waitAmount;
            if(collectibleSpawnCooldown <= 0)
            {
                CalculateCooldownAndSpeed();
                SpawnCollectibles();
            }
        }
    }
    private void GameStarted()
    {
        ResetData();
        currentSpeed = baseSpeed;
        collectibleSpawnCooldown = startCollectibleSpawnCooldown;
        RespawnEnemy();
        gameScoreText.UpdateScore(gameData.gameScore);
        lifesText.UpdateLifes(gameData.lifes);
        Player player = Instantiate(playerPrefab);
        player.LoadGameManager(this);
        player.LoadSkin(playerSettings.playerSkin);
    }
    private void ResetData()
    {
        gameData.lifes = 3;
        gameData.gameScore = 0;
        gameData.satanTwos = 0;
        gameData.coinsCollected = 0;
        gameData.soulsPunished = 0;
    }
    private void EndGame()
    {
        if(playerStatistics.highestScore < gameData.gameScore)
        {
            playerStatistics.highestScore = gameData.gameScore;
        }
        playerStatistics.satanTwos += gameData.satanTwos;
        playerStatistics.coinsCollected += gameData.coinsCollected;
        playerStatistics.soulsPunished += gameData.soulsPunished;
        FindObjectOfType<DataManager>().SaveData();
        FindObjectOfType<ProgressSceneLoader>().LoadScene("GameOverScene");
    }
    public void ScorePoint()
    {
        gameData.gameScore++;
        gameStage += gameStageIncrease;
        gameScoreText.UpdateScore(gameData.gameScore);
    }
    public void LoseLife()
    {
        gameStage -= 1f;
        gameData.lifes--;
        lifesText.UpdateLifes(gameData.lifes);
        if (gameData.lifes < 0)
        {
            lifesText.GameOver();
            Invoke("EndGame", 2f);
        }
    }
    public void RespawnEnemy()
    {
        int selectSkin = Random.Range(0, skinsAvailable.handSkins.Length);
        float positionX = Random.Range(-maxSpawnDistanceX, maxSpawnDistanceX);
        Enemy enemy = Instantiate(enemyPrefab);
        enemy.LoadGameManager(this);
        enemy.LoadSkin(skinsAvailable.handSkins[selectSkin]);
        enemy.GetComponent<SpawnPosition>().RandomizePosition(positionX, spawnDistanceY);
        enemy.GetComponent<MoveDownside>().SetSpeed(Random.Range(currentSpeed - randomSpeedRange, currentSpeed + randomSpeedRange));
    }
    private void SpawnSouls()
    {
        float positionX = Random.Range(-maxSpawnDistanceX, maxSpawnDistanceX);

        Soul soul = Instantiate(soulPrefab);
        soul.LoadGameManager(this);
        soul.GetComponent<SpawnPosition>().RandomizePosition(positionX, spawnDistanceY);
        soul.GetComponent<MoveDownside>().SetSpeed(Random.Range(randomSpeedRange, currentSpeed + randomSpeedRange));
    }
    private void SpawnCollectibles()
    {
        float positionX = Random.Range(-maxSpawnDistanceX, maxSpawnDistanceX);

        int selectCollectible = Random.Range(0, collectiblesPrefabs.Length);
        Collectible collectible = Instantiate(collectiblesPrefabs[selectCollectible]);
        collectible.LoadGameManager(this);
        collectible.GetComponent<SpawnPosition>().RandomizePosition(positionX, spawnDistanceY);
        collectible.GetComponent<MoveDownside>().SetSpeed(Random.Range(currentSpeed - randomSpeedRange, currentSpeed + randomSpeedRange));
        
    }
    private void CalculateCooldownAndSpeed()
    {
        currentSpeed = baseSpeed + gameStage;
        collectibleSpawnCooldown = startCollectibleSpawnCooldown - gameStage;
        if (collectibleSpawnCooldown < 1f)
        {
            collectibleSpawnCooldown = 1f;
        }
    }
}
