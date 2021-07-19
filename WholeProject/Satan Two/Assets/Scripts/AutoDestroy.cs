using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 3f;
    void Start()
    {
        Invoke("DestroyMe", timeToDestroy);
    }
    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
