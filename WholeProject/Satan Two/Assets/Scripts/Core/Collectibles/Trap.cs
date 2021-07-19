using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Collectible
{
    protected override void ManageRewards()
    {
        FindObjectOfType<Player>().Death();
    }
}
