using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FadeTween : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float timeToFade;
    [SerializeField] float targetOpacity;
    void Awake()
    {
        if (text != null)
        {
            text.DOFade(0, 0);
        }
        if (image != null)
        {
            image.DOFade(0, 0);
        }
        if (spriteRenderer != null)
        {
            spriteRenderer.DOFade(0, 0);
        }
    }
    public void Appear()
    {
        if (text != null)
        {
            text.DOFade(targetOpacity, timeToFade);
        }
        if (image != null)
        {
            image.DOFade(targetOpacity, timeToFade);
        }
        if (spriteRenderer != null)
        {
            spriteRenderer.DOFade(targetOpacity, timeToFade);
        }
    }
    public void Disappear()
    {
        if (text != null)
        {
            text.DOFade(0, timeToFade);
        }
        if (image != null)
        {
            image.DOFade(0, timeToFade);
        }
        if (spriteRenderer != null)
        {
            spriteRenderer.DOFade(0, timeToFade);
        }
    }
}