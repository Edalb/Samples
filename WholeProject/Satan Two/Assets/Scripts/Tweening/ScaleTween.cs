using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleTween : MonoBehaviour
{
    [SerializeField] RectTransform targetRectTransform;
    [SerializeField] float timeToScale = 0.6f;
    [SerializeField] bool autoActivate;
    void Awake()
    {
        targetRectTransform.localScale = new Vector3(0, 0, 0);
        targetRectTransform.DOScale(0, 0);
    }
    private void Start()
    {
        if (autoActivate)
        {
            Scale();
        }
    }
    public void Scale()
    {
        targetRectTransform.DOScale(new Vector3(1f, 1f, 1f), timeToScale);
    }
    public void ScaleDown()
    {
        targetRectTransform.DOScale(new Vector3(0f, 0f, 0f), timeToScale).OnComplete(Disappear);
    }
    private void Disappear()
    {
        this.gameObject.SetActive(false);
    }
}
