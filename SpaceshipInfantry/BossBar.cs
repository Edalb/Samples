using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    [SerializeField] Image bossBarFillImage;
    private float _fillAmount;

    [SerializeField] Health bossHealth;
    private int currentHealth;
    private int bossMaxHealth;

    [SerializeField] GameObject bossBarObject;
    [SerializeField] GameObject victoryUI;
    private void Start()
    {
        bossMaxHealth = bossHealth.MaximumHealth;
    }
    public void UpdateBar()
    {
        currentHealth = bossHealth.CurrentHealth;
        _fillAmount = ((float)currentHealth / bossMaxHealth);
        bossBarFillImage.fillAmount = _fillAmount;
        CheckWinCondition();
    }
    private void CheckWinCondition()
    {
        if(currentHealth <= 0)
        {
            Victory();
        }
    }
    private void Victory()
    {
        victoryUI.SetActive(true);
        bossBarObject.SetActive(false);
    }
}
