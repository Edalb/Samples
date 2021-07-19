using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    protected override void ManageRewards()
    {
        gameManager.ScorePoint();
        gameManager.gameData.coinsCollected++;
    }
}
