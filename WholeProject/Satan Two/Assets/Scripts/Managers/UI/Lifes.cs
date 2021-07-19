using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lifes : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateLifes(int lifes)
    {
        textMesh.text = "x" + lifes.ToString();
    }
    public void GameOver()
    {
        textMesh.text = "x0";
        textMesh.color = Color.red;
    }
}
