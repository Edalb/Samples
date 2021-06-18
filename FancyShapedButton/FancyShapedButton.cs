using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FancyShapedButton : MonoBehaviour
{
    //Don't forget to set sprites Read/Write Enabled to true
    [Tooltip("Minimal transparency of the button to be able to respond for clicking")]
    [Range(0f, 1f)]
    [SerializeField] float AlphaValue;
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaValue;
    }
}
