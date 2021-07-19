using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinsManager : MonoBehaviour
{
    [SerializeField] SkinsAvailable skinsAvailable;
    [SerializeField] PlayerSettings playerSettings;
    [SerializeField] PlayerStatistics playerStatistics;

    [SerializeField] Image skinPreview;
    [SerializeField] Image skinPadlock;
    [SerializeField] Button selectSkinButton;
    [SerializeField] TextMeshProUGUI selectSkinText;

    [SerializeField] GameObject requirementsPanel;
    [SerializeField] TextMeshProUGUI requirementsText;
    [SerializeField] TextMeshProUGUI requirementsProgressText;
    private int previewedSkinNumber;

    [SerializeField] int soulsRequired;
    [SerializeField] int coinsRequired;
    [SerializeField] int highestScoreRequired;
    public void LoadSkin()
    {
        playerSettings.playerSkin = skinsAvailable.handSkins[playerSettings.skinNumber];
        skinPreview.sprite = playerSettings.playerSkin;
        previewedSkinNumber = playerSettings.skinNumber;
        DisableButton();
    }
    public void PreviousSkin()
    {
        if (previewedSkinNumber > 0)
        {
            previewedSkinNumber--;
        }
        else
        {
            previewedSkinNumber = skinsAvailable.handSkins.Length - 1;
        }
        skinPreview.sprite = skinsAvailable.handSkins[previewedSkinNumber];
        ManagePadlock();
    }
    public void NextSkin()
    {
        if(previewedSkinNumber < skinsAvailable.handSkins.Length - 1)
        {
            previewedSkinNumber++;
        } else
        {
            previewedSkinNumber = 0;
        }
        skinPreview.sprite = skinsAvailable.handSkins[previewedSkinNumber];
        ManagePadlock();
    }
    private void DisableButton()
    {
        selectSkinButton.interactable = false;
        selectSkinText.text = "Selected";
    }
    private void ActivateButton()
    {
        selectSkinButton.interactable = true;
        selectSkinText.text = "Select";
    }
    private void UnlockButton()
    {
        selectSkinButton.interactable = true;
        selectSkinText.text = "Unlock";
    }
    public void ManageButton()
    {
        if(selectSkinText.text == "Select")
        {
            playerSettings.skinNumber = previewedSkinNumber;
            playerSettings.playerSkin = skinsAvailable.handSkins[playerSettings.skinNumber];
            FindObjectOfType<DataManager>().SaveData();
            DisableButton();
        } else
        {
            requirementsPanel.SetActive(true);
            requirementsPanel.GetComponent<ScaleTween>().Scale();
            requirementsPanel.GetComponent<FadeTween>().Appear();
            switch (previewedSkinNumber)
            {
                case 2:
                    requirementsText.text = "Punish souls: " + soulsRequired;
                    requirementsProgressText.text = "Souls punished: " + playerStatistics.soulsPunished;
                    break;
                case 3:
                    requirementsText.text = "Collect coins: " + coinsRequired;
                    requirementsProgressText.text = "Coins collected: " + playerStatistics.coinsCollected;
                    break;
                case 4:
                    requirementsText.text = "Beat GameScore: " + highestScoreRequired;
                    requirementsProgressText.text = "Highest score: " + playerStatistics.highestScore;
                    break;
            }
        }
    }
    private void ManagePadlock()
    {
        if(IsSkinUnlocked() == true)
        {
            skinPadlock.color = new Color(1, 1, 1, 0);
            if(previewedSkinNumber == playerSettings.skinNumber)
            {
                DisableButton();
            } else
            {
                ActivateButton();
            }
        } else
        {
            skinPadlock.color = new Color(1, 1, 1, 1);
            UnlockButton();
        }
    }
    private bool IsSkinUnlocked()
    {
        switch (previewedSkinNumber)
        {
            case 2:
                if(playerStatistics.soulsPunished >= soulsRequired)
                {
                    return true;
                } else
                {
                    return false;
                }
            case 3:
                if (playerStatistics.coinsCollected >= coinsRequired)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 4:
                if (playerStatistics.highestScore >= highestScoreRequired)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return true;
        }
    }
}
