using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroCard : MonoBehaviour
{
    public int heroPosition;
    public bool isFilled = false;
    [SerializeField] Image characterImage;
    [SerializeField] TextMeshProUGUI stackSize;
    [SerializeField] FadeTween[] fadeTweens;
    public CharacterAttributes loadedHeroData;
    static StorageUI storage;

    [SerializeField] CurrentHeroes currentHeroes;
    void Start()
    {
        storage = FindObjectOfType<StorageUI>();
        if(currentHeroes.selectedHeroes != null)
        {
            foreach (CharacterAttributes hero in currentHeroes.selectedHeroes)
            {
                if (hero.startPosition == heroPosition)
                {
                    FillCard(hero, false);
                }
            }
        }
    }
    public void FillCard(CharacterAttributes hero, bool isClicked)
    {
        isFilled = true;
        loadedHeroData = hero;
        loadedHeroData.startPosition = heroPosition;
        characterImage.sprite = loadedHeroData.heroSprite;
        stackSize.text = loadedHeroData.stack.ToString();
        if (isClicked)
        {
            storage.heroesBar.selectedHeroes.Add(loadedHeroData);
        }   
        storage.ManageStartButton();
        foreach (FadeTween fadingObject in fadeTweens)
        {
            fadingObject.Appear();
        }
    }
    public void CleanCard()
    {
        if (isFilled)
        {
            isFilled = false;
            storage.SetIconReady(loadedHeroData);
            loadedHeroData.startPosition = 0;
            storage.heroesBar.selectedHeroes.Remove(loadedHeroData);
            loadedHeroData.isDeployed = false;
            loadedHeroData = null;
            storage.ManageStartButton();
            foreach (FadeTween fadingObject in fadeTweens)
            {
                fadingObject.Disappear();
            }
        }
    }
}