using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Collectible
{
    protected override void ManageRewards()
    {
        gameManager.gameData.soulsPunished++;
    }
}
