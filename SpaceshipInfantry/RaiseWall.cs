using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RaiseWall : MonoBehaviour
{
    private Collider objectCollider;
    [SerializeField] float endPositionY = 0f;
    [SerializeField] float raisingTime = 2f;
    private void Start()
    {
        objectCollider = GetComponent<Collider>();
    }
    public void EnableWall()
    {
        objectCollider.enabled = true;
        transform.DOMoveY(endPositionY, raisingTime);
    }
}
