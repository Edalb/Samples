using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public void RandomizePosition(float positionX, float positionY)
    {
        this.gameObject.transform.position = new Vector2(positionX, positionY);
    }
}
